using EmpirePump.Web.QBSDK;
using EmpirePump.Web.Services.SalesOrders;
using Microsoft.AspNetCore.Mvc;

namespace EmpirePump.Web.Controllers;

[ApiController]
public class SalesOrderController(QBConnection connection) : ControllerBase
{
    [HttpPost]
    public IActionResult CreateSalesOrder(CreateSalesOrder request)
    {
        var rq = request.ToSalesOrderAddRq();
        connection.ProcessRequest(rq);

        if (rq.StatusCode != 0)
        {
            return StatusCode(500, rq.StatusMessage);
        }

        var modRq = rq.Ret?.ToModRq();
        if (modRq == null)
        {
            return StatusCode(500, "Unable to convert to ModRq");
        }

        connection.ProcessRequest(modRq);
        if (modRq.StatusCode != 0)
        {
            return StatusCode(500, modRq.StatusMessage);
        }

        connection.DisplayTxn(TxnType.SalesOrder, modRq.TxnID!);

        return Ok();
    }
}
