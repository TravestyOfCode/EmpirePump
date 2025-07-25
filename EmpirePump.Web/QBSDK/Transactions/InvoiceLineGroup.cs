using EmpirePump.Web.QBSDK.Types;
using System.Xml.Serialization;

namespace EmpirePump.Web.QBSDK.Transactions;

public class InvoiceLineGroup : InvoiceLineBase
{
    [XmlElement("ItemGroupRef")]
    public ListRef? ItemGroup { get; set; }
    public bool? IsPrintItemsInGroup { get; set; }
    public decimal? TotalAmount { get; set; }
    [XmlElement("InvoiceLineRet")]
    public List<InvoiceLine>? InvoiceLines { get; set; }
}
