using System.Xml.Linq;

namespace EmpirePump.Web.QBSDK;

public class SalesOrderModRq : IQBXElement
{
    public string? TxnID { get; set; }
    public string? EditSequence { get; set; }
    public ListRef? CustomerRef { get; set; }
    public ListRef? ClassRef { get; set; }
    public ListRef? TemplateRef { get; set; }
    public DateOnly? TxnDate { get; set; }
    public string? RefNumber { get; set; }
    public Address? BillAddress { get; set; }
    public Address? ShipAddress { get; set; }
    public string? PONumber { get; set; }
    public ListRef? TermsRef { get; set; }
    public DateOnly? DueDate { get; set; }
    public ListRef? SalesRepRef { get; set; }
    public string? FOB { get; set; }
    public DateOnly? ShipDate { get; set; }
    public ListRef? ShipMethodRef { get; set; }
    public ListRef? ItemSalesTaxRef { get; set; }
    public bool? IsManuallyClosed { get; set; }
    public string? Memo { get; set; }
    public ListRef? CustomerMsgRef { get; set; }
    public bool? IsToBePrinted { get; set; }
    public bool? IsToBeEmailed { get; set; }
    public ListRef? CustomerSalesTaxCodeRef { get; set; }
    public string? Other { get; set; }
    public float? ExchangeRate { get; set; }
    public List<SalesOrderLineModBase>? SalesOrderLineMods { get; set; }

    public XElement ToXElement(QBContext? context)
    {
        // TODO: Add CA/UK and check for context support.
        context ??= new QBContext();

        var mod = new XElement("SalesOrdeMod")
        .AddElement(TxnID)
        .AddElement(EditSequence)
        .AddElement(CustomerRef)
        .AddElement(ClassRef)
        .AddElement(TemplateRef)
        .AddElement(TxnDate)
        .AddElement(RefNumber)
        .AddElement(BillAddress)
        .AddElement(ShipAddress)
        .AddElement(PONumber)
        .AddElement(TermsRef)
        .AddElement(DueDate)
        .AddElement(SalesRepRef)
        .AddElement(FOB)
        .AddElement(ShipDate)
        .AddElement(ShipMethodRef)
        .AddElement(ItemSalesTaxRef)
        .AddElement(IsManuallyClosed)
        .AddElement(Memo)
        .AddElement(CustomerMsgRef)
        .AddElement(IsToBePrinted)
        .AddElement(IsToBeEmailed)
        .AddElement(CustomerSalesTaxCodeRef)
        .AddElement(Other)
        .AddElement(ExchangeRate)
        .AddElement(SalesOrderLineMods);

        return new XElement(nameof(SalesOrderModRq), mod);
    }
}