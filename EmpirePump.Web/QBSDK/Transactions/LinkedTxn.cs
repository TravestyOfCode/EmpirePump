using EmpirePump.Web.QBSDK.Enums;

namespace EmpirePump.Web.QBSDK.Transactions;

public class LinkedTxn
{
    public int? TxnID { get; set; }
    public TxnType? TxnType { get; set; }
    public DateOnly? TxnDate { get; set; }
    public string? RefNumber { get; set; }
    public LinkType? LinkType { get; set; }
}
