using System.Xml.Serialization;

namespace EmpirePump.Web.QBSDK;

public abstract class Item
{
    public string? ListID { get; set; }
    public DateTime? TimeCreated { get; set; }
    public DateTime? TimeModified { get; set; }
    public string? EditSequence { get; set; }
    public string? Name { get; set; }
    public string? FullName { get; set; }
    public decimal? QuantityOnHand { get; set; }
}

[XmlRoot("ItemQueryRs")]
public class ItemList
{
    [XmlElement("ItemServiceRet", typeof(Service))]
    [XmlElement("ItemDiscountRet", typeof(Discount))]
    [XmlElement("ItemFixedAssetRet", typeof(FixedAsset))]
    [XmlElement("ItemGroupRet", typeof(Group))]
    [XmlElement("ItemInventoryRet", typeof(Inventory))]
    [XmlElement("ItemInventoryAssemblyRet", typeof(InventoryAssembly))]
    [XmlElement("ItemNonInventoryRet", typeof(NonInventory))]
    [XmlElement("ItemOtherChargeRet", typeof(OtherCharge))]
    [XmlElement("ItemPaymentRet", typeof(Payment))]
    [XmlElement("ItemSalesTaxRet", typeof(SalesTax))]
    [XmlElement("ItemSalesTaxGroupRet", typeof(SalesTaxGroup))]
    [XmlElement("ItemSubtotalRet", typeof(Subtotal))]
    public List<Item>? RetList { get; set; }
}