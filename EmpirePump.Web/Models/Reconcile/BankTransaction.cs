namespace EmpirePump.Web.Models.Reconcile;

public class BankTransaction
{
    // Identifies which QB transaction this bank transaction is matched to.
    public string? QBTxnID { get; set; }

    // The transaction date. Matched QB Txn should be within a tollerance of this date.
    public DateOnly TxnDate { get; set; }

    // The bank's description. Can be used to create matching rules to ensure
    // this doesn't get matched to the wrong vendor. For example, if the description
    // contains "OMNY" match to QB Vendor "NY Dept of Transportation".
    public string? Description { get; set; }

    // The debit (purchase) amount. If null, CreditAmount must have a value.
    public decimal? DebitAmount { get; set; }

    // The credit (deposit) amount. If null, DebitAmount must have a value.
    public decimal? CreditAmount { get; set; }

    // The amount expressed as a positive value for Credits and negative for Debits.
    public decimal Amount
    {
        get
        {
            if (DebitAmount != null)
            {
                return DebitAmount.Value * -1;
            }
            else if (CreditAmount != null)
            {
                return CreditAmount.Value;
            }
            throw new InvalidOperationException("Amount is not set.");
        }
        set
        {
            if (value >= 0)
            {
                CreditAmount = value;
                DebitAmount = null;
            }
            else
            {
                DebitAmount = value * -1;
                CreditAmount = null;
            }
        }
    }

    // The check number, if applicable.
    public string? CheckNumber { get; set; }
}
