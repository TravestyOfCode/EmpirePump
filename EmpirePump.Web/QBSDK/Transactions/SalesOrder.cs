using System.Xml.Serialization;

namespace EmpirePump.Web.QBSDK;

public class SalesOrder
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
    [XmlElement("TemplateRef")]
    public ListRef? Template { get; set; }
    public DateOnly? TxnDate { get; set; }
    public string? RefNumber { get; set; }
    public Address? BillAddress { get; set; }
    public Address? ShipAddress { get; set; }
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
    public decimal? TotalAmount { get; set; }
    [XmlElement("CurrencyRef")]
    public ListRef? Currency { get; set; }
    public float? ExchangeRate { get; set; }
    public decimal? TotalAmountInHomeCurrency { get; set; }
    public bool? IsManuallyClosed { get; set; }
    public bool? IsFullyInvoiced { get; set; }
    public string? Memo { get; set; }
    [XmlElement("CustomerMsgRef")]
    public ListRef? CustomerMsg { get; set; }
    public bool? IsToBePrinted { get; set; }
    public bool? IsToBeEmailed { get; set; }
    [XmlElement("CustomerSalesTaxCodeRef")]
    public ListRef? CustomerSalesTaxCode { get; set; }
    public string? Other { get; set; }
    public string? ExternalGUID { get; set; }
    [XmlElement("LinkedTxn")]
    public List<LinkedTxn>? LinkedTxns { get; set; }
    [XmlElement("SalesOrderLineRet")]
    [XmlElement("SalesOrderLineGroupRet")]
    public List<SalesOrderLineBase>? SalesOrderLines { get; set; }
    [XmlElement("DataExtRet")]
    public List<DataExt>? DataExts { get; set; }
}
