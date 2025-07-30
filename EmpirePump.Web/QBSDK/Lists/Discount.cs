using System.Xml.Serialization;

namespace EmpirePump.Web.QBSDK;

[XmlRoot("ItemDiscountRet")]
public class Discount : Item
{
    public string? FullName { get; set; }
    public string? BarCodeValue { get; set; }
    public bool? IsActive { get; set; }
    [XmlElement("ClassRef")]
    public ListRef? Class { get; set; }
    [XmlElement("ParentRef")]
    public ListRef? Parent { get; set; }
    public int? Sublevel { get; set; }
    public string? ItemDesc { get; set; }
    [XmlElement("SalesTaxCodeRef")]
    public ListRef? SalesTaxCode { get; set; }
    public decimal? DiscountRate { get; set; }
    public decimal? DiscountRatePercent { get; set; }
    [XmlElement("AccountRef")]
    public ListRef? Account { get; set; }
    public string? ExternalGUID { get; set; }
    [XmlElement("DataExtRet")]
    public List<DataExt>? DataExts { get; set; }
}

