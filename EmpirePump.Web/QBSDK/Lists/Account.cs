using System.Xml.Serialization;

namespace EmpirePump.Web.QBSDK;

public class Account
{
    public string? ListID { get; set; }
    public DateTime? TimeCreated { get; set; }
    public DateTime? TimeModified { get; set; }
    public string? EditSequence { get; set; }
    public string? Name { get; set; }
    public string? FullName { get; set; }
    public bool? IsActive { get; set; }
    [XmlElement("ParentRef")]
    public ListRef? Parent { get; set; }
    public int? Sublevel { get; set; }
    public AccountType? AccountType { get; set; }
    public SpecialAccountType? SpecialAccountType { get; set; }
    public bool? IsTaxAccount { get; set; }
    public string? AccountNumber { get; set; }
    public string? BankNumber { get; set; }
    public string? Desc { get; set; }
    public decimal? Balance { get; set; }
    public decimal? TotalBalance { get; set; }
    [XmlElement("SalesTaxCodeRef")]
    public ListRef? SalesTaxCode { get; set; }
    [XmlElement("TaxLineInfoRet")]
    public List<TaxLineInfo>? TaxLineInfos { get; set; }
    public CashFlowClassification? CashFlowClassification { get; set; }
    [XmlElement("CurrencyRef")]
    public ListRef? Currency { get; set; }
    [XmlElement("DataExtRet")]
    public List<DataExt>? DataExts { get; set; }
}