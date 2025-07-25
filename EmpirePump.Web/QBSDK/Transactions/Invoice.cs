using EmpirePump.Web.QBSDK.Types;
using System.Xml.Serialization;

namespace EmpirePump.Web.QBSDK.Transactions;

public class Invoice
{
    public string? TxnID { get; set; }
    public DateTime? TimeCreated { get; set; }
    public DateTime? TimeModified { get; set; }
    public string? EditSequence { get; set; }
    public int? TxnNumber { get; set; }
    [XmlElement("CustomerRef")]
    public ListRef? Customer { get; set; }
    [XmlElement("ClassRef")]
    public ListRef? Class { get; set; }
    [XmlElement("ARAccountRef")]
    public ListRef? ARAccount { get; set; }
    [XmlElement("TemplateRef")]
    public ListRef? Template { get; set; }
    public DateOnly? TxnDate { get; set; }
    public string? RefNumber { get; set; }
    public Address? BillAddress { get; set; }
    public Address? ShipAddress { get; set; }
    public bool? IsPending { get; set; }
    public bool? IsFinanceCharge { get; set; }
    public string? PONumber { get; set; }
    [XmlElement("TermsRef")]
    public ListRef? Terms { get; set; }
    public DateOnly? DueDate { get; set; }
    [XmlElement("SalesRepRef")]
    public ListRef? SalesRep { get; set; }
    public string? FOB { get; set; }
    public DateOnly? ShipDate { get; set; }
    [XmlElement("ShipMethodRef")]
    public ListRef? ShipMethod { get; set; }
    public decimal? Subtotal { get; set; }
    [XmlElement("ItemSalesTaxRef")]
    public ListRef? ItemSalesTax { get; set; }
    public decimal? SalesTaxPercentage { get; set; }
    public decimal? SalesTaxTotal { get; set; }
    public decimal? AppliedAmount { get; set; }
    public decimal? BalanceRemaining { get; set; }
    [XmlElement("CurrencyRef")]
    public ListRef? Currency { get; set; }
    public float? ExchangeRate { get; set; }
    public decimal? BalanceRemainingInHomeCurrency { get; set; }
    public string? Memo { get; set; }
    public bool? IsPaid { get; set; }
    [XmlElement("CustomerMsgRef")]
    public ListRef? CustomerMsg { get; set; }
    public bool? IsToBePrinted { get; set; }
    public bool? IsToBeEmailed { get; set; }
    public bool? IsTaxIncluded { get; set; }
    [XmlElement("CustomerSalesTaxCodeRef")]
    public ListRef? CustomerSalesTaxCode { get; set; }
    public decimal? SuggestedDiscountAmount { get; set; }
    public DateOnly? SuggestedDiscountDate { get; set; }
    public string? Other { get; set; }
    public string? ExternalGUID { get; set; }
    [XmlElement("LinkedTxn")]
    public List<LinkedTxn>? LinkedTxns { get; set; }
    [XmlElement("InvoiceLineRet", typeof(InvoiceLine))]
    [XmlElement("InvoiceLineGroupRet", typeof(InvoiceLineGroup))]
    public List<InvoiceLineBase>? InvoiceLines { get; set; }
    [XmlElement("DataExtRet")]
    public List<DataExt>? DataExts { get; set; }
}

