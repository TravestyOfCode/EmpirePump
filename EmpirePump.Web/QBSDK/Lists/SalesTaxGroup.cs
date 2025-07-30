using System.Xml.Serialization;

namespace EmpirePump.Web.QBSDK;

[XmlRoot("ItemSalesTaxGroupRet")]
public class SalesTaxGroup : Item
{
    public string? BarCodeValue { get; set; }
    public bool? IsActive { get; set; }
    public string? ItemDesc { get; set; }
    public string? ExternalGUID { get; set; }
    [XmlElement("ItemSalesTaxRef")]
    public ListRef? ItemSalesTax { get; set; }
    [XmlElement("DataExtRet")]
    public List<DataExt>? DataExts { get; set; }
}

