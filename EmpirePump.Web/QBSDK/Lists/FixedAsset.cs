using System.Xml.Serialization;

namespace EmpirePump.Web.QBSDK;

[XmlRoot("ItemFixedAssetRet")]
public class FixedAsset : Item
{
    public string? BarCodeValue { get; set; }
    public bool? IsActive { get; set; }
    [XmlElement("ClassRef")]
    public ListRef? Class { get; set; }
    public AquiredAs? AcquiredAs { get; set; }
    public string? PurchaseDesc { get; set; }
    public DateOnly? PurchaseDate { get; set; }
    public decimal? PurchaseCost { get; set; }
    public string? VendorOrPayeeName { get; set; }
    [XmlElement("AssetAccountRef")]
    public ListRef? AssetAccount { get; set; }
    public FixedAssetSalesInfo? FixedAssetSalesInfo { get; set; }
    public string? AssetDesc { get; set; }
    public string? Location { get; set; }
    public string? PONumber { get; set; }
    public string? SerialNumber { get; set; }
    public DateOnly? WarrantyExpDate { get; set; }
    public string? Notes { get; set; }
    public string? AssetNumber { get; set; }
    public decimal? CostBasis { get; set; }
    public decimal? YearEndAccumulatedDepreciation { get; set; }
    public decimal? YearEndBookValue { get; set; }
    public string? ExternalGUID { get; set; }
    [XmlElement("DataExtRet")]
    public List<DataExt>? DataExts { get; set; }
}

