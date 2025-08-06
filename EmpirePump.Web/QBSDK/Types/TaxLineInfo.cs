using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace EmpirePump.Web.QBSDK;

public class TaxLineInfo
{
    public int? TaxLineID { get; set; }
    public string? TaxLineName { get; set; }

    public XElement? ToXElement(string name = "TaxLineID") => TaxLineID == null ? null : new XElement(name, TaxLineID);
}

internal static class TaxLineInfoExtensions
{
    public static XElement AddElement(this XElement element, TaxLineInfo? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(value.ToXElement(name));
        }
        return element;
    }
}