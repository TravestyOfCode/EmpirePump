using System.Xml.Serialization;

namespace EmpirePump.Web.QBSDK;

[XmlRoot("ItemOtherChargeRet")]
public class OtherCharge : Item
{
    //public string? FullName { get; set; }
    public string? BarCodeValue { get; set; }
    public bool? IsActive { get; set; }
    [XmlElement("ClassRef")]
    public ListRef? Class { get; set; }
    [XmlElement("ParentRef")]
    public ListRef? Parent { get; set; }
    public int? Sublevel { get; set; }
    [XmlElement("SalesTaxCodeRef")]
    public ListRef? SalesTaxCode { get; set; }
    public SalesOrPurchase? SalesOrPurchase { get; set; }
    public SalesAndPurchase? SalesAndPurchase { get; set; }
    public SpecialItemType? SpecialItemType { get; set; }
    public string? ExternalGUID { get; set; }
    [XmlElement("DataExtRet")]
    public List<DataExt>? DataExts { get; set; }
}

