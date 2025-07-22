namespace EmpirePump.Web.QBSDK.Transactions;

public abstract class TxnBase
{
    public string? TxnID { get; set; }
    public DateTime? TimeCreated { get; set; }
    public DateTime? TimeModified { get; set; }
    public string? EditSequence { get; set; }
    public int? TxnNumber { get; set; }
    public DateOnly? TxnDate { get; set; }
}
