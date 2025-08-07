using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace EmpirePump.Web.QBSDK;

public class RefNumberFilter
{
    public MatchCriterion MatchCriterion { get; set; }

    public required string RefNumber { get; set; }

    public XElement ToXElement(string name = nameof(RefNumberFilter))
    {
        return new XElement(name)
            .AddElement(MatchCriterion)
            .AddElement(RefNumber);
    }
}

internal static class RefNumberFilterExtensions
{
    public static XElement AddElement(this XElement element, RefNumberFilter? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(value.ToXElement(name));
        }
        return element;
    }
}