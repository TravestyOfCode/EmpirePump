using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace EmpirePump.Web.QBSDK.Types;

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

public static class ListRefExtensions
{
    public static XElement AddElement(this XElement element, ListRef? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(value.ToXElement(name));
        }
        return element;
    }

    public static XElement AddElementIf(this XElement element, bool isSupported, ListRef? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null && isSupported)
        {
            element.Add(value.ToXElement(name));
        }
        return element;
    }
}
