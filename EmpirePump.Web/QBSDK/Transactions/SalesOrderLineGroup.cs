using System.Xml.Serialization;

namespace EmpirePump.Web.QBSDK;

public class SalesOrderLineGroup : SalesOrderLineBase
{
    public bool? IsPrintItemsInGroup { get; set; }
    public decimal? TotalAmount { get; set; }
    [XmlElement("SalesOrderLineRet")]
    public List<SalesOrderLine>? SalesOrderLines { get; set; }
}