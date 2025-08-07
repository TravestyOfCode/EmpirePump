using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace EmpirePump.Web.QBSDK;

internal static class XElementExtensions
{
    public static XElement AddElement(this XElement element, string? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(new XElement(name, value));
        }
        return element;
    }

    public static XElement AddElement(this XElement element, int? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(new XElement(name, value));
        }
        return element;
    }

    public static XElement AddElement(this XElement element, bool? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(new XElement(name, value.Value ? "true" : "false"));
        }
        return element;
    }

    public static XElement AddElement(this XElement element, decimal? value, int decimalPlaces = 2, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(new XElement(name, value.Value.ToString($"F{decimalPlaces}")));
        }
        return element;
    }

    public static XElement AddElement(this XElement element, float? value, int decimalPlaces = 2, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(new XElement(name, value.Value.ToString($"F{decimalPlaces}")));
        }
        return element;
    }

    public static XElement AddElement(this XElement element, DateTime? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(new XElement(name, value.Value.ToString("yyyy-MM-ddTHH:mm:ss")));
        }
        return element;
    }

    public static XElement AddElement(this XElement element, DateOnly? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(new XElement(name, value.Value.ToString("yyyy-MM-dd")));
        }
        return element;
    }

    public static XElement AddElement<T>(this XElement element, T? value, [CallerArgumentExpression(nameof(value))] string name = "") where T : struct, Enum
    {
        if (value != null)
        {
            element.Add(new XElement(name, value.ToString()));
        }
        return element;
    }

    public static XElement AddElement<T>(this XElement element, T value, [CallerArgumentExpression(nameof(value))] string name = "") where T : struct, Enum
    {
        element.Add(new XElement(name, value.ToString()));

        return element;
    }

    public static XElement AddElement(this XElement element, List<string>? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(value.Select(v => new XElement(name, v)).ToList());
        }
        return element;
    }

    public static XElement AddElement(this XElement element, List<int>? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(value.Select(v => new XElement(name, v)).ToList());
        }
        return element;
    }

    public static XElement AddElement<T>(this XElement element, List<T>? values, [CallerArgumentExpression(nameof(values))] string name = "") where T : struct, Enum
    {
        if (values != null)
        {

            element.Add(values.Select(v => new XElement(name, v.ToString())));
        }
        return element;
    }

    public static XElement AddElement(this XElement element, XElement? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(value);
        }
        return element;
    }

    public static XElement AddElement(this XElement element, IToXElement? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(value.ToXElement(name));
        }
        return element;
    }

    public static XElement AddElement(this XElement element, List<IToXElement>? values, [CallerArgumentExpression(nameof(values))] string name = "")
    {
        if (values != null)
        {
            element.Add(values.Select(v => v.ToXElement(name)));
        }
        return element;
    }

    // CONDITIONAL ADD ELEMENT FUNCTIONS 
    public static XElement AddElementIf(this XElement element, bool isSupported, string? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null && isSupported)
        {
            element.Add(new XElement(name, value));
        }
        return element;
    }

    public static XElement AddElementIf(this XElement element, bool isSupported, List<string>? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null && isSupported)
        {
            element.Add(value.Select(v => new XElement(name, v)).ToList());
        }
        return element;
    }

    public static XElement AddElementIf(this XElement element, bool isSupported, bool? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null && isSupported)
        {
            element.Add(new XElement(name, value.Value ? "true" : "false"));
        }
        return element;
    }

    public static XElement AddElementIf(this XElement element, bool isSupported, IToXElement? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null && isSupported)
        {
            element.Add(value.ToXElement(name));
        }
        return element;
    }

    public static XElement AddElementIf(this XElement element, bool isSupported, List<IToXElement>? values, [CallerArgumentExpression(nameof(values))] string name = "")
    {
        if (values != null && isSupported)
        {
            element.Add(values.Select(v => v.ToXElement(name)));
        }
        return element;
    }
}
