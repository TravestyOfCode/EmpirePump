using EmpirePump.Web.QBSDK;

namespace EmpirePump.Web.Services.SalesOrders;

public class CreateSalesOrder
{
    public required string CustomerName { get; set; }
    public required string ParentName { get; set; }
    public DateOnly? TxnDate { get; set; }
    public required string RefNumber { get; set; }
    public string? JobDescription { get; set; }
    public string? PONumber { get; set; }
    public string? JobCategory { get; set; }
    public List<Note>? NoteList { get; set; }
    public List<Labor>? LaborList { get; set; }

    public SalesOrderAddRq ToSalesOrderAddRq()
    {
        return new SalesOrderAddRq()
        {
            CustomerRef = new() { FullName = $"{ParentName}:{CustomerName}" },
            TemplateRef = new() { FullName = "Custom Sales Order" },
            TxnDate = TxnDate,
            RefNumber = RefNumber,
            PONumber = PONumber,
            SalesOrderLines = [new SalesOrderLineGroupAdd() { ItemGroupRef = new() { FullName = "A" } }]
        };
    }

    public SalesOrderModRq ToSalesOrderModRq(SalesOrder so)
    {
        var result = so.ToModRq();
        result.SalesOrderLines = [GenerateSalesOrderLineMod()];
        return result;
    }

    private SalesOrderLineGroupMod GenerateSalesOrderLineMod()
    {
        var result = new SalesOrderLineGroupMod()
        {
            TxnLineID = "-1",
            ItemGroupRef = new() { FullName = "A" },
            SalesOrderLineMod = []
        };

        result.SalesOrderLineMod.Add(new SalesOrderLineMod()
        {
            TxnLineID = "-1",
            Desc = JobDescription
        });

        var lines = NoteList.ToSalesOrderLineMod();
        if (lines != null)
        {
            result.SalesOrderLineMod.AddRange(lines);
        }

        result.SalesOrderLineMod.Add(new SalesOrderLineMod() { TxnLineID = "-1" });
        result.SalesOrderLineMod.Add(new SalesOrderLineMod() { TxnLineID = "-1", ItemRef = new() { FullName = "Subtotal" } });
        result.SalesOrderLineMod.Add(new SalesOrderLineMod() { TxnLineID = "-1", ItemRef = new() { FullName = "OH:Minus Total" } });

        return result;
    }
}
