using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace EmpirePump.Web.QBSDK;

public class ListRef
{
    public string? ListID { get; set; }
    public string? FullName { get; set; }

    public XElement ToXElement(string name = nameof(ListRef))
    {
        return new XElement(name)
            .AddElement(ListID)
            .AddElement(FullName);
    }
}

internal static class ListRefExtensions
{
    public static XElement AddElement(this XElement element, ListRef? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(value.ToXElement(name));
        }
        return element;
    }
}
