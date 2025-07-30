using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace EmpirePump.Web.QBSDK;

public class LinkedTxn
{
    public string? TxnID { get; set; }
    public TxnType? TxnType { get; set; }
    public DateOnly? TxnDate { get; set; }
    public string? RefNumber { get; set; }
    public LinkType? LinkType { get; set; }
    public decimal? Amount { get; set; }

    public XElement ToXElement(string name = nameof(LinkedTxn)) => new XElement(name)
        .AddElement(TxnID)
        .AddElement(TxnType)
        .AddElement(TxnDate)
        .AddElement(RefNumber)
        .AddElement(LinkType)
        .AddElement(Amount);
}

internal static class LinkedTxnExtensions
{
    public static XElement AddElement(this XElement element, LinkedTxn? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(value.ToXElement(name));
        }
        return element;
    }
}