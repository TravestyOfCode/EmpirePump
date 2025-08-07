using System.Xml.Linq;

namespace EmpirePump.Web.QBSDK;

public class ListFilter : IToXElement
{
    public List<string>? ListID { get; set; }
    public List<string>? FullName { get; set; }

    public XElement ToXElement(string name = nameof(ListFilter)) => new XElement(name)
        .AddElement(ListID)
        .AddElement(FullName);
}