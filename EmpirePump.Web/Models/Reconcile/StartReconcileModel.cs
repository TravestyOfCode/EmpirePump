using Microsoft.AspNetCore.Http;

namespace EmpirePump.Web.Models.Reconcile;

public class StartReconcileModel
{
    public required string AccountListID { get; set; }
    public required IFormFile StatementFile { get; set; }
    public DateOnly? EndDate { get; set; }
}
