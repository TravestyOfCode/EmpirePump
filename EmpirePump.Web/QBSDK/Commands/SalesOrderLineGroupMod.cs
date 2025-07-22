using EmpirePump.Web.QBSDK.Commands;
using EmpirePump.Web.QBSDK.Transactions;
using EmpirePump.Web.QBSDK.Types;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace EmpirePump.Web.QBSDK.Commands;

public class SalesOrderLineGroupMod : SalesOrderLineModBase
{
    public string? TxnLineID { get; set; }
    public ListRef? ItemGroupRef { get; set; }
    public decimal? Quantity { get; set; }
    public string? UnitOfMeasure { get; set; }
    public ListRef? OverrideUOMSetRef { get; set; }
    public List<SalesOrderLineMod>? SalesOrderLineMods { get; set; }

    public XElement ToXElement(string name = nameof(SalesOrderLineGroupMod))
    {
        return new XElement(name)
            .AddElement(TxnLineID)
            .AddElement(ItemGroupRef)
            .AddElement(Quantity)
            .AddElement(UnitOfMeasure)
            .AddElement(SalesOrderLineMods, "SalesOrderLineMod");
    }
}

public static class SalesOrderLineGroupModExtensions
{
    public static XElement AddElement(this XElement element, List<SalesOrderLineGroupMod>? values, [CallerArgumentExpression(nameof(values))] string name = "")
    {
        if (values != null)
        {
            foreach (var value in values)
            {
                element.Add(value.ToXElement(name));
            }
        }
        return element;
    }

    public static SalesOrderLineGroupMod ToMod(this SalesOrderLineGroup solg)
    {
        return new SalesOrderLineGroupMod()
        {
            TxnLineID = solg.TxnLineID,
            ItemGroupRef = solg.ItemGroup,
            Quantity = solg.Quantity,
            UnitOfMeasure = solg.UnitOfMeasure,
            OverrideUOMSetRef = solg.OverrideUOMSet,
            SalesOrderLineMods = solg.SalesOrderLines.ToMod()
        };
    }

    public static List<SalesOrderLineGroupMod>? ToMod(this List<SalesOrderLineGroup>? sol)
    {
        return sol?.Select(s => s.ToMod()).ToList();
    }
}
