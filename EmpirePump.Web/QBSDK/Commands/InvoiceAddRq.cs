using EmpirePump.Web.QBSDK.Transactions;
using EmpirePump.Web.QBSDK.Types;
using System.Xml.Linq;

namespace EmpirePump.Web.QBSDK.Commands;

public class InvoiceAddRq : CommandRq<Invoice>
{
    public ListRef? CustomerRef { get; set; }
    public ListRef? ClassRef { get; set; }
    public ListRef? ARAccountRef { get; set; }
    public ListRef? TemplateRef { get; set; }
    public DateOnly? TxnDate { get; set; }
    public string? RefNumber { get; set; }
    public Address? BillAddress { get; set; }
    public Address? ShipAddress { get; set; }
    public bool? IsPending { get; set; }
    public bool? IsFinanceCharge { get; set; }
    public string? PONumber { get; set; }
    public ListRef? TermsRef { get; set; }
    public DateOnly? DueDate { get; set; }
    public ListRef? SalesRepRef { get; set; }
    public string? FOB { get; set; }
    public DateOnly? ShipDate { get; set; }
    public ListRef? ShipMethodRef { get; set; }
    public ListRef? ItemSalesTaxRef { get; set; }
    public string? Memo { get; set; }
    public ListRef? CustomerMsgRef { get; set; }
    public bool? IsToBePrinted { get; set; }
    public bool? IsToBeEmailed { get; set; }
    public bool? IsTaxIncluded { get; set; }
    public ListRef? CustomerSalesTaxCodeRef { get; set; }
    public string? Other { get; set; }
    public float? ExchangeRate { get; set; }
    public string? ExternalGUID { get; set; }
    public string? LinkToTxnID { get; set; }
    public List<SetCredit>? SetCredits { get; set; }
    public List<InvoiceLineAddBase>? InvoiceLines { get; set; }

    public override XElement ToXElement(QBContext? context)
    {
        throw new NotImplementedException();
    }
}