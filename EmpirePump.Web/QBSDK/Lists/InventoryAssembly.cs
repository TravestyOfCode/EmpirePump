using System.Xml.Serialization;

namespace EmpirePump.Web.QBSDK;

[XmlRoot("ItemInventoryAssemblyRet")]
public class InventoryAssembly : Item
{
    //public string? FullName { get; set; }
    public string? BarCodeValue { get; set; }
    public bool? IsActive { get; set; }
    [XmlElement("ClassRef")]
    public ListRef? Class { get; set; }
    [XmlElement("ParentRef")]
    public ListRef? Parent { get; set; }
    public int? Sublevel { get; set; }
    public string? ManufacturerPartNumber { get; set; }
    [XmlElement("UnitOfMeasureSetRef")]
    public ListRef? UnitOfMeasureSet { get; set; }
    [XmlElement("SalesTaxCodeRef")]
    public ListRef? SalesTaxCode { get; set; }
    public string? SalesDesc { get; set; }
    public decimal? SalesPrice { get; set; }
    [XmlElement("IncomeAccountRef")]
    public ListRef? IncomeAccount { get; set; }
    public string? PurchaseDesc { get; set; }
    public decimal? PurchaseCost { get; set; }
    [XmlElement("COGSAccountRef")]
    public ListRef? COGSAccount { get; set; }
    [XmlElement("PrefVendorRef")]
    public ListRef? PrefVendor { get; set; }
    [XmlElement("AssetAccountRef")]
    public ListRef? AssetAccount { get; set; }
    public decimal? BuildPoint { get; set; }
    public decimal? Max { get; set; }
    //public decimal? QuantityOnHand { get; set; }
    public decimal? AverageCost { get; set; }
    public decimal? QuantityOnOrder { get; set; }
    public decimal? QuantityOnSalesOrder { get; set; }
    public string? ExternalGUID { get; set; }
    [XmlElement("ItemInventoryAssemblyLine")]
    public List<InventoryAssemblyLine>? InventoryAssemblyLines { get; set; }
    [XmlElement("DataExtRet")]
    public List<DataExt>? DataExts { get; set; }
}

