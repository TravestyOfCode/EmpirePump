using System.Xml.Linq;

namespace EmpirePump.Web.QBSDK;

public class StringRangeFilter : IToXElement
{
    public string? From { get; set; }
    public string? To { get; set; }

    public XElement ToXElement(string? name)
    {
        return new XElement($"{name}RangeFilter")
            .AddElement(From, $"From{name}")
            .AddElement(To, $"To{name}");
    }
}