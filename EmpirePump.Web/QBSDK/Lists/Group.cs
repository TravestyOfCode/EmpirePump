using System.Xml.Serialization;

namespace EmpirePump.Web.QBSDK;

[XmlRoot("ItemGroupRet")]
public class Group : Item
{
    public string? BarCodeValue { get; set; }
    public bool? IsActive { get; set; }
    public string? ItemDesc { get; set; }
    [XmlElement("UnitOfMeasureSetRef")]
    public ListRef? UnitOfMeasureSet { get; set; }
    public bool? IsPrintItemsInGroup { get; set; }
    public SpecialItemType? SpecialItemType { get; set; }
    public string? ExternalGUID { get; set; }
    [XmlElement("ItemGroupLine")]
    public List<GroupLine>? GroupLines { get; set; }
    [XmlElement("DataExtRet")]
    public List<DataExt>? DataExts { get; set; }
}

