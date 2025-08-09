using EmpirePump.Web.Models.Reconcile;
using EmpirePump.Web.QBSDK;
using EmpirePump.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmpirePump.Web.Controllers;

public class ReconcileController(QBConnection connection) : Controller
{
    [HttpGet]
    public IActionResult Index(StartReconcileModel startRec)
    {
        // Get the reconcileable accounts from QB
        var accountQuery = AccountQueryRq.GetReconcilableAccounts();
        accountQuery.ProcessRequest(connection);

        if (accountQuery.StatusCode == 0)
        {
            var vm = new IndexViewModel()
            {
                Accounts = accountQuery.RetList!.ToDictionary(a => a.ListID!, a => a.Name!),
                SelectedAccountListID = startRec.AccountListID,
                StatementFile = startRec.StatementFile,
                EndDate = startRec.EndDate
            };

            return View(vm);
        }

        return StatusCode(500, accountQuery.StatusMessage);
    }

    [HttpPost]
    public IActionResult Start(StartReconcileModel startRec)
    {
        // The range that a transaction can be between to be condisered a match
        int dateSpread = 4;

        // Parse the StatementFile csv into BankTransaction
        var bankTxns = new StatementCSVParser().ParseCSV(startRec.StatementFile);

        // Get uncleared transactions for the account from QB
        var qbRequest = TransactionQueryRq.GetByAccountIDAndDateRange(startRec.AccountListID, startRec.EndDate.AddDays(-60), startRec.EndDate.AddDays(5));
        qbRequest.ProcessRequest(connection);

        if (qbRequest.StatusCode != 0)
        {
            return StatusCode(500, $"<div class=\"text-danger\">There was an error getting the QB transactions: {qbRequest.StatusMessage}</div>");
        }

        // Generate a 
        var qbTxns = qbRequest.RetList!.Select(qb => new Models.Reconcile.Transaction()
        {
            TxnID = qb.TxnID,
            TxnDate = qb.TxnDate!.Value,
            Description = qb.Entity?.FullName,
            Amount = qb.Amount!.Value,
            CheckNumber = qb.RefNumber
        }).ToList();

        // For each of the BankTransactions, try to find a match to a QB transaction        
        foreach (var bankTxn in bankTxns)
        {
            // A qb match must not already be matched, have the exact same amount,
            // and be between the bank date +/- the date spread value.
            // TODO: Also try to match based on description.
            var foundQBTxn = qbTxns.Where(q => q.MatchedTxnID == null && q.Amount == bankTxn.Amount &&
                                            q.TxnDate >= bankTxn.TxnDate.AddDays(dateSpread * -1) && q.TxnDate <= bankTxn.TxnDate.AddDays(dateSpread))
                                    .FirstOrDefault();

            if (foundQBTxn != null)
            {
                bankTxn.MatchedTxnID = foundQBTxn.TxnID;
                foundQBTxn.MatchedTxnID = bankTxn.TxnID;
            }
        }

        return PartialView(new MatchedTransactionModel()
        {
            BankTransactions = bankTxns,
            QBTransactions = qbTxns
        });

        //return StatusCode(500, "<div class=\"text-danger\">Not implemented yet</div>");
    }
}
