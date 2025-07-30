using System.Xml.Linq;

namespace EmpirePump.Web.QBSDK;

public class SalesOrderLineGroupAdd : SalesOrderLineAddBase
{
    public ListRef? ItemGroupRef { get; set; }

    public override XElement ToXElement(string name = nameof(SalesOrderLineGroupAdd))
    {
        return new XElement(nameof(SalesOrderLineGroupAdd))
        .AddElement(ItemGroupRef)
        .AddElement(Quantity)
        .AddElement(UnitOfMeasure)
        .AddElement(InventorySiteRef)
        .AddElement(InventorySiteLocationRef)
        .AddElement(DataExt);
    }
}
