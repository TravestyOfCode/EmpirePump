using System.Xml.Serialization;

namespace EmpirePump.Web.QBSDK;

[XmlRoot("ItemGroupLine")]
public class GroupLine
{
    [XmlElement("ItemRef")]
    public ListRef? Item { get; set; }
    public decimal? Quantity { get; set; }
    public string? UnitOfMeasure { get; set; }
}
