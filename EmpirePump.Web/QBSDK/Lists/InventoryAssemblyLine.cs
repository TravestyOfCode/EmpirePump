using System.Xml.Serialization;

namespace EmpirePump.Web.QBSDK;

[XmlRoot("ItemInventoryAssemblyLine")]
public class InventoryAssemblyLine
{
    [XmlElement("ItemInventoryRef")]
    public ListRef? ItemInventory { get; set; }
    public decimal? Quantity { get; set; }
}
