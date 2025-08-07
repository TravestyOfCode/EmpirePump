using System.Xml.Linq;

namespace EmpirePump.Web.QBSDK;

public class NameFilter : IToXElement
{
    public MatchCriterion MatchCriterion { get; set; }

    public required string Name { get; set; }

    public XElement ToXElement(string name = nameof(NameFilter))
    {
        return new XElement(name)
            .AddElement(MatchCriterion)
            .AddElement(Name);
    }
}
