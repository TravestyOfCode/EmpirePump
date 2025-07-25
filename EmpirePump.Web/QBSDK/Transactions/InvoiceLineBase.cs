using EmpirePump.Web.QBSDK.Types;
using System.Xml.Serialization;

namespace EmpirePump.Web.QBSDK.Transactions;

public abstract class InvoiceLineBase
{
    public string? TxnLineID { get; set; }
    public string? Desc { get; set; }
    public decimal? Quantity { get; set; }
    public string? UnitOfMeasure { get; set; }
    [XmlElement("OverrideUOMSetRef")]
    public ListRef? OverrideUOMSet { get; set; }
    [XmlElement("DataExtRet")]
    public List<DataExt>? DataExts { get; set; }
}
