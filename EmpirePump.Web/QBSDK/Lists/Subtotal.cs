using System.Xml.Serialization;

namespace EmpirePump.Web.QBSDK;

[XmlRoot("ItemSubtotalRet")]
public class Subtotal : Item
{
    public string? BarCodeValue { get; set; }
    public bool? IsActive { get; set; }
    public string? ItemDesc { get; set; }
    public SpecialItemType? SpecialItemType { get; set; }
    public string? ExternalGUID { get; set; }
    [XmlElement("DataExtRet")]
    public List<DataExt>? DataExts { get; set; }
}

