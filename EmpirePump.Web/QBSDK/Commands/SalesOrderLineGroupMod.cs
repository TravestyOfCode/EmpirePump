using System.Xml.Linq;

namespace EmpirePump.Web.QBSDK;

public class SalesOrderLineGroupMod : SalesOrderLineModBase
{
    public ListRef? ItemGroupRef { get; set; }
    public List<SalesOrderLineMod>? SalesOrderLineMod { get; set; }

    public override XElement ToXElement(string name = nameof(SalesOrderLineGroupMod))
    {
        return new XElement(nameof(SalesOrderLineGroupMod))
        .AddElement(TxnLineID)
        .AddElement(ItemGroupRef)
        .AddElement(Quantity)
        .AddElement(UnitOfMeasure)
        .AddElement(OverrideUOMSetRef)
        .AddElement(SalesOrderLineMod);
    }
}