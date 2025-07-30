using System.Xml.Serialization;

namespace EmpirePump.Web.QBSDK;

public class SalesOrderLine : SalesOrderLineBase
{
    public decimal? Rate { get; set; }
    public decimal? RatePercent { get; set; }
    [XmlElement("ClassRef")]
    public ListRef? Class { get; set; }
    public decimal? Amount { get; set; }
    [XmlElement("InventorySiteRef")]
    public ListRef? InventorySite { get; set; }
    [XmlElement("InventorySiteLocationRef")]
    public ListRef? InventorySiteLocation { get; set; }
    public string? SerialNumber { get; set; }
    public string? LotNumber { get; set; }
    [XmlElement("SalesTaxCodeRef")]
    public ListRef? SalesTaxCode { get; set; }
    public decimal? Invoiced { get; set; }
    public bool? IsManuallyClosed { get; set; }
    public string? Other1 { get; set; }
    public string? Other2 { get; set; }
}