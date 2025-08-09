namespace EmpirePump.Web.Models.Reconcile;

public class MatchedTransactionModel
{
    public List<Transaction> BankTransactions { get; set; } = [];
    public List<Transaction> QBTransactions { get; set; } = [];
}
