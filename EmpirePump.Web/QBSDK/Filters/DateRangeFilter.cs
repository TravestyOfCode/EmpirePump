using System.Xml.Linq;

namespace EmpirePump.Web.QBSDK;

public class DateRangeFilter : IToXElement
{
    public DateOnly? From { get; set; }
    public DateOnly? To { get; set; }
    public DateMacro? DateMacro { get; set; }

    public XElement ToXElement(string? name) => new XElement($"{name}DateRangeFilter")
        .AddElement(From, $"From{name}")
        .AddElement(To, $"To{name}")
        .AddElement(DateMacro);
}
