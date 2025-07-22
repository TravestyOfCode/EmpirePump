using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace EmpirePump.Web.QBSDK;

internal static class XAttributeExtensions
{
    public static XElement AddAttribute(this XElement element, string? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(new XAttribute(name, value));
        }
        return element;
    }

    public static XElement AddAttribute(this XElement element, bool? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(new XAttribute(name, value.Value ? "true" : "false"));
        }
        return element;
    }

    public static XElement AddAttribute(this XElement element, DateTime? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(new XAttribute(name, value.Value.ToString("yyyy-MM-ddTHH:mm:ss")));
        }
        return element;
    }

    public static XElement AddAttribute<T>(this XElement element, T? value, [CallerArgumentExpression(nameof(value))] string name = "") where T : struct, Enum
    {
        if (value != null)
        {
            element.Add(new XAttribute(name, value.Value.ToString()));
        }
        return element;
    }

    public static XElement AddAttributeIf(this XElement element, bool isSupported, string? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null && isSupported)
        {
            element.Add(new XAttribute(name, value));
        }
        return element;
    }

    public static XElement AddAttributeIf<T>(this XElement element, bool isSupported, T? value, [CallerArgumentExpression(nameof(value))] string name = "") where T : struct, Enum
    {
        if (value != null && isSupported)
        {
            element.Add(new XAttribute(name, value.Value.ToString()));
        }
        return element;
    }
}
