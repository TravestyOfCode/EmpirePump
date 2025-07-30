using System.Xml.Serialization;

namespace EmpirePump.Web.QBSDK;

public class SalesOrPurchase
{
    public string? Desc { get; set; }
    public decimal? Price { get; set; }
    public decimal? PricePercent { get; set; }
    [XmlElement("AccountRef")]
    public ListRef? Account { get; set; }
}

