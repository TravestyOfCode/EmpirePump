using System.Xml.Linq;

namespace EmpirePump.Web.QBSDK;

public interface IQBXElement
{
    public XElement ToXElement(QBContext? context);
}
