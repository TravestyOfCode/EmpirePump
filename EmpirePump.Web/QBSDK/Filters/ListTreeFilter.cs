using System.Xml.Linq;

namespace EmpirePump.Web.QBSDK;

public class ListTreeFilter : IToXElement
{
    public List<string>? ListID { get; set; }
    public List<string>? FullName { get; set; }
    public List<string>? ListIDWithChildren { get; set; }
    public List<string>? FullNameWithChildren { get; set; }

    public XElement ToXElement(string name = nameof(ListTreeFilter)) => new XElement(name)
        .AddElement(ListID)
        .AddElement(FullName)
        .AddElement(ListIDWithChildren)
        .AddElement(FullNameWithChildren);
}
