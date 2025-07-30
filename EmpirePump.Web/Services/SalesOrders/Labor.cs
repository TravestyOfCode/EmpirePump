namespace EmpirePump.Web.Services.SalesOrders;

public class Labor
{
    public int Id { get; set; }
    public required string Employee { get; set; }
    // Should be calculated in increments of 15 minutes
    public decimal? LaborTime { get; set; }
    // Used to link to a specific note
    public int? NoteId { get; set; }

    // TODO: Figure out what data is pulled from Service Fusion for the labor time
    public required string LaborText { get; set; }
}
