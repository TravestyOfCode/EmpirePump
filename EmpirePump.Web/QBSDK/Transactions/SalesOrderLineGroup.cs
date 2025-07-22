using EmpirePump.Web.QBSDK.Types;
using System.Xml.Serialization;

namespace EmpirePump.Web.QBSDK.Transactions;

public class SalesOrderLineGroup : SalesOrderLineBase
{
    public string? TxnLineID { get; set; }
    [XmlElement("ItemGroupRef")]
    public ListRef? ItemGroup { get; set; }
    public string? Desc { get; set; }
    public decimal? Quantity { get; set; }
    public string? UnitOfMeasure { get; set; }
    [XmlElement("OverrideUOMSetRef")]
    public ListRef? OverrideUOMSet { get; set; }
    public bool? IsPrintItemsInGroup { get; set; }
    public decimal? TotalAmount { get; set; }
    [XmlElement("SalesOrderLineRet")]
    public List<SalesOrderLine>? SalesOrderLines { get; set; }
    [XmlElement("DataExtRet")]
    public List<DataExt>? DataExts { get; set; }
}

