using System.Xml.Serialization;

namespace EmpirePump.Web.QBSDK;

public abstract class SalesOrderLineBase
{
    public string? TxnLineID { get; set; }
    [XmlElement("ItemRef")]
    [XmlElement("ItemGroupRef")]
    public ListRef? Item { get; set; }
    public string? Desc { get; set; }
    public decimal? Quantity { get; set; }
    public string? UnitOfMeasure { get; set; }
    [XmlElement("OverrideUOMSetRef")]
    public ListRef? OverrideUOMSet { get; set; }
    [XmlElement("DataExtRet")]
    public List<DataExt>? DataExts { get; set; }
}
