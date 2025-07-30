using System.Xml.Serialization;

namespace EmpirePump.Web.QBSDK;

public class SalesAndPurchase
{
    public string? SalesDesc { get; set; }
    public decimal? SalesPrice { get; set; }
    [XmlElement("IncomeAccountRef")]
    public ListRef? IncomeAccount { get; set; }
    public string? PurchaseDesc { get; set; }
    public decimal? PurchaseCost { get; set; }
    [XmlElement("ExpenseAccountRef")]
    public ListRef? ExpenseAccount { get; set; }
    [XmlElement("PrefVendorRef")]
    public ListRef? PrefVendor { get; set; }
}

