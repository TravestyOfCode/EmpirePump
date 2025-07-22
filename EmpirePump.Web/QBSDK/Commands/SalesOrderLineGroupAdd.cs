using EmpirePump.Web.QBSDK;
using EmpirePump.Web.QBSDK.Commands;
using EmpirePump.Web.QBSDK.Types;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace EmpirePump.Web.QBSDK.Commands;

public class SalesOrderLineGroupAdd : SalesOrderLineAddBase
{
    public ListRef? ItemGroupRef { get; set; }
    public decimal? Quantity { get; set; }
    public string? UnitOfMeasure { get; set; }
    public ListRef? InventorySiteRef { get; set; }
    public ListRef? InventorySiteLocationRef { get; set; }
    [XmlElement("DataExt")]
    public List<DataExt>? DataExts { get; set; }

    public XElement ToXElement(string name = nameof(SalesOrderLineGroupAdd))
    {
        return new XElement(name)
            .AddElement(ItemGroupRef)
            .AddElement(Quantity)
            .AddElement(UnitOfMeasure)
            .AddElement(InventorySiteRef)
            .AddElement(InventorySiteLocationRef)
            .AddElement(DataExts, nameof(DataExt));
    }
}

