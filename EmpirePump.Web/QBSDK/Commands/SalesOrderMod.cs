using EmpirePump.Web.QBSDK.Commands;
using EmpirePump.Web.QBSDK.Enums;
using EmpirePump.Web.QBSDK.Transactions;
using EmpirePump.Web.QBSDK.Types;
using System.Xml.Linq;

namespace EmpirePump.Web.QBSDK.Commands;

public class SalesOrderMod : CommandRq<SalesOrder>
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
    public bool? IsTaxIncluded { get; set; }
    public ListRef? CustomerSalesTaxCodeRef { get; set; }
    public string? Other { get; set; }
    public float? ExchangeRate { get; set; }
    public List<SalesOrderLineModBase>? SalesOrderLines { get; set; }
    public List<string>? IncludeRetElement { get; set; }

    public override XElement ToXElement(QBContext? context = null)
    {
        context ??= new QBContext();
        if (!context.Supports(QBEdition.Any, 3, 0))
        {
            throw new NotSupportedException();
        }
        var mod = new XElement(nameof(SalesOrderMod))
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
            .AddElementIf(context.Supports(QBEdition.CA | QBEdition.UK, 6, 0), IsTaxIncluded)
            .AddElement(CustomerSalesTaxCodeRef)
            .AddElement(Other)
            .AddElement(ExchangeRate)
            .AddElement(SalesOrderLines)
            .AddElement(IncludeRetElement);

        return new XElement("SalesOrderModRq", mod);

    }
}

public static class SalesOrderModExtensions
{
    public static SalesOrderMod ToMod(this SalesOrder so)
    {
        return new SalesOrderMod()
        {
            TxnID = so.TxnID,
            EditSequence = so.EditSequence,
            CustomerRef = so.Customer,
            ClassRef = so.Class,
            TemplateRef = so.Template,
            TxnDate = so.TxnDate,
            RefNumber = so.RefNumber,
            BillAddress = so.BillAddress,
            ShipAddress = so.ShipAddress,
            PONumber = so.PONumber,
            TermsRef = so.Terms,
            DueDate = so.DueDate,
            SalesRepRef = so.SalesRep,
            FOB = so.FOB,
            ShipDate = so.ShipDate,
            ShipMethodRef = so.ShipMethod,
            ItemSalesTaxRef = so.ItemSalesTax,
            IsManuallyClosed = so.IsManuallyClosed,
            Memo = so.Memo,
            CustomerMsgRef = so.CustomerMsg,
            IsToBePrinted = so.IsToBePrinted,
            IsToBeEmailed = so.IsToBeEmailed,
            //IsTaxIncluded = so.IsTaxIncluded,
            CustomerSalesTaxCodeRef = so.CustomerSalesTaxCode,
            Other = so.Other,
            ExchangeRate = so.ExchangeRate,
            SalesOrderLines = so.SalesOrderLines.ToMod()
        };
    }
}

