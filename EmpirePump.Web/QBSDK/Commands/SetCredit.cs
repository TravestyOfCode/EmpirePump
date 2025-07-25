namespace EmpirePump.Web.QBSDK.Commands;

public class SetCredit
{
    public required string CreditTxnID { get; set; }
    public decimal AppliedAmount { get; set; }
    public bool? Override { get; set; }
}
