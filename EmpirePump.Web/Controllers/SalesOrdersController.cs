using Microsoft.AspNetCore.Mvc;

namespace EmpirePump.Web.Controllers;

[ApiController]
public class SalesOrdersController(ILogger<SalesOrdersController> logger) : ControllerBase
{
    [HttpPost("[controller]/[action]")]
    public IActionResult Create([FromBody] string? notes)
    {
        logger.LogDebug(notes);

        return Ok();
    }
}
