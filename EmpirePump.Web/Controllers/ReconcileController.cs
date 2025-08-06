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
        return StatusCode(500, "<div class=\"text-danger\">Action has not yet been implemented.</div>");
    }
}
