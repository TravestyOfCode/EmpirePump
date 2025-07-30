using System.Xml.Serialization;

namespace EmpirePump.Web.QBSDK;

[XmlRoot("ItemSalesTaxRet")]
public class SalesTax : Item
{
    public string? BarCodeValue { get; set; }
    public bool? IsActive { get; set; }
    [XmlElement("ClassRef")]
    public ListRef? Class { get; set; }
    public string? ItemDesc { get; set; }
    public decimal? TaxRate { get; set; }
    [XmlElement("TaxVendorRef")]
    public ListRef? TaxVendor { get; set; }
    public string? ExternalGUID { get; set; }
    [XmlElement("DataExtRet")]
    public List<DataExt>? DataExts { get; set; }
}

