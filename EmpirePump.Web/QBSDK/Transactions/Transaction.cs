using System.Xml.Serialization;

namespace EmpirePump.Web.QBSDK;

public class Transaction
{
    public TxnType? TxnType { get; set; }
    public string? TxnID { get; set; }
    public string? TxnLineID { get; set; }
    public DateTime? TimeCreated { get; set; }
    public DateTime? TimeModified { get; set; }
    [XmlElement("EntityRef")]
    public ListRef? Entity { get; set; }
    [XmlElement("AccountRef")]
    public ListRef? Account { get; set; }
    public DateOnly? TxnDate { get; set; }
    public string? RefNumber { get; set; }
    public decimal? Amount { get; set; }
    [XmlElement("CurrencyRef")]
    public ListRef? Currency { get; set; }
    public float? ExchangeRate { get; set; }
    public decimal? AmountInHomeCurrency { get; set; }
    public string? Memo { get; set; }
}

[XmlRoot("TransactionQueryRs")]
public class TransactionList
{
    [XmlElement("TransactionRet")]
    public List<Transaction>? RetList { get; set; }
}