using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmpirePump.Web.Models.Reconcile;

public class IndexViewModel
{
    public Dictionary<string, string> Accounts { get; set; } = [];

    public string? SelectedAccountListID { get; set; }

    public IFormFile? StatementFile { get; set; }

    public DateOnly? EndDate { get; set; }

    public SelectList AccountList => new SelectList(Accounts, "Key", "Value", SelectedAccountListID);
}
