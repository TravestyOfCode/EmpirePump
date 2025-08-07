using EmpirePump.Web.Models.Reconcile;
using EmpirePump.Web.QBSDK;
using Microsoft.AspNetCore.Mvc;

namespace EmpirePump.Web.Controllers;

public class ReconcileController : Controller
{
    [HttpGet]
    public IActionResult Index(StartReconcileModel startRec, [FromServices] QBConnection connection)
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
        // Parse the StatementFile into BankTransaction
        //var bankTxns = new StatementCSVParser().ParseCSV(startRec.StatementFile);

        // Get uncleared transactions for the account from QB

        // For each of the BankTransactions, try to find a match to a QB transaction
        // Return a list of BankTransactions that match QB transactions,
        // as well as the bank and qb transactions that are not matched

        return StatusCode(500, "<div class=\"text-danger\">Not implemented yet</div>");
    }
}
