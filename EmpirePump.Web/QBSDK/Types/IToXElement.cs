using System.Xml.Linq;

namespace EmpirePump.Web.QBSDK;

public interface IToXElement
{
    public XElement ToXElement(string name);
}
