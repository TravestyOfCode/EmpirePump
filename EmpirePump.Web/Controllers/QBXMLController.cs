using EmpirePump.Web.QBSDK;
using Microsoft.AspNetCore.Mvc;

namespace EmpirePump.Web.Controllers;

public class QBXMLController(QBConnection connection) : Controller
{
    public IActionResult Index()
    {
        var qbxml = new QBXML();
        qbxml.AddRequest(AccountQueryRq.GetReconcilableAccounts());

        qbxml.ProcessRequests(connection);

        return Ok(qbxml.Requests.FirstOrDefault()?.StatusMessage);
    }
}
