using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace EmpirePump.Web.QBSDK;

public class ListFilter
{
    public List<string>? ListID { get; set; }
    public List<string>? FullName { get; set; }

    public XElement ToXElement(string name = nameof(ListFilter)) => new XElement(name)
        .AddElement(ListID)
        .AddElement(FullName);
}

internal static class ListFilterExtensions
{
    public static XElement AddElement(this XElement element, ListFilter? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(value.ToXElement(name));
        }
        return element;
    }

    public static XElement AddElementIf(this XElement element, bool isSupported, ListFilter? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null && isSupported)
        {
            element.Add(value.ToXElement(name));
        }
        return element;
    }
}