using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace EmpirePump.Web.QBSDK;

public class DataExt
{
    public string? OwnerID { get; set; }
    public string? DataExtName { get; set; }
    public string? DataExtValue { get; set; }
    public DataExtType? DataExtType { get; set; }

    public XElement ToXElement(string name = nameof(DataExt))
    {
        return new XElement(name)
            .AddElement(OwnerID)
            .AddElement(DataExtName)
            .AddElement(DataExtValue);
    }
}

internal static class DataExtExtensions
{
    public static XElement AddElement(this XElement element, DataExt? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(value.ToXElement(name));
        }
        return element;
    }

    public static XElement AddElement(this XElement element, List<DataExt>? values, [CallerArgumentExpression(nameof(values))] string name = "")
    {
        if (values != null)
        {
            foreach (var value in values)
            {
                element.Add(value.ToXElement(name));
            }
        }
        return element;
    }
}
