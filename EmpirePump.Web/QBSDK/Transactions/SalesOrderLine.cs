using EmpirePump.Web.QBSDK.Types;
using System.Xml.Serialization;

namespace EmpirePump.Web.QBSDK.Transactions;

public class SalesOrderLine : SalesOrderLineBase
{
    public string? TxnLineID { get; set; }
    [XmlElement("ItemRef")]
    public ListRef? Item { get; set; }
    public string? Desc { get; set; }
    public decimal? Quantity { get; set; }
    public string? UnitOfMeasure { get; set; }
    [XmlElement("OverrideUOMSetRef")]
    public ListRef? OverrideUOMSet { get; set; }
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
    [XmlElement("DataExtRet")]
    public List<DataExt>? DataExts { get; set; }
}

