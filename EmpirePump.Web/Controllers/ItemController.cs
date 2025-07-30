using EmpirePump.Web.QBSDK;
using Microsoft.AspNetCore.Mvc;

namespace EmpirePump.Web.Controllers;

public class ItemController(QBConnection connection) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Search(NameFilter filter, ItemType? itemType)
    {
        var rq = new ItemQueryRq() { NameFilter = filter, ItemType = itemType };
        rq.ProcessRequest(connection);
        return PartialView(rq);
    }
}
