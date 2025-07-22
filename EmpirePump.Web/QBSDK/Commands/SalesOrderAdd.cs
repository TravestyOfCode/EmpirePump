using EmpirePump.Web.QBSDK;
using EmpirePump.Web.QBSDK.Commands;
using EmpirePump.Web.QBSDK.Enums;
using EmpirePump.Web.QBSDK.Transactions;
using EmpirePump.Web.QBSDK.Types;
using System.Xml.Linq;

namespace EmpirePump.Web.QBSDK.Commands;

public class SalesOrderAdd : CommandRq<SalesOrder>
{
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
    public bool? IsTaxIncluded { get; set; }
    public ListRef? CustomerSalesTaxCodeRef { get; set; }
    public string? Other { get; set; }
    public float? ExchangeRate { get; set; }
    public string? ExternalGUID { get; set; }
    public List<SalesOrderLineAddBase>? SalesOrderLines { get; set; }
    public List<string>? IncludeRetElement { get; set; }

    public override XElement ToXElement(QBContext? context = null)
    {
        context ??= new QBContext();
        if (!context.Supports(QBEdition.Any, 2, 1))
        {
            throw new NotSupportedException();
        }
        var add = new XElement(nameof(SalesOrderAdd))
            .AddAttributeIf(context.Supports(QBEdition.Any, 2, 0), defMacro)
            .AddElement(CustomerRef)
            .AddElement(ClassRef)
            .AddElementIf(context.Supports(QBEdition.Any, 3, 0), TemplateRef)
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
            .AddElementIf(context.Supports(QBEdition.CA | QBEdition.UK, 6, 0), IsTaxIncluded)
            .AddElement(CustomerSalesTaxCodeRef)
            .AddElement(Other)
            .AddElement(ExchangeRate)
            .AddElement(ExternalGUID)
            .AddElement(SalesOrderLines)
            .AddElement(IncludeRetElement);

        return new XElement("SalesOrderAddRq")
            .AddAttributeIf(context.Supports(QBEdition.Any, 2, 0), defMacro)
            .AddElement(add);

    }
}

