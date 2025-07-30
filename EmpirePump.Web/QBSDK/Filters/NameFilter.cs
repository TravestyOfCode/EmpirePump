using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace EmpirePump.Web.QBSDK;

public class NameFilter
{
    public MatchCriterion MatchCriterion { get; set; }

    public required string Name { get; set; }

    public XElement ToXElement(string name = nameof(NameFilter))
    {
        return new XElement(name)
            .AddElement(MatchCriterion)
            .AddElement(Name);
    }
}

internal static class NameFilterExtensions
{
    public static XElement AddElement(this XElement element, NameFilter? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(value.ToXElement(name));
        }
        return element;
    }
}
