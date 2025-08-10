using System.Xml.Linq;

namespace EmpirePump.Web.QBSDK;

public class NameRangeFilter : IToXElement
{
    public string? FromName { get; set; }
    public string? ToName { get; set; }

    public XElement ToXElement(string name = nameof(NameRangeFilter))
    {
        return new XElement(name)
            .AddElement(FromName)
            .AddElement(ToName);
    }
}