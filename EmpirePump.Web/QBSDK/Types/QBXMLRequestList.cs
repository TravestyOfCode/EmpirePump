using System.Xml.Linq;
using System.Xml.Serialization;

namespace EmpirePump.Web.QBSDK;

public class QBXMLRequestList
{
    [XmlElement("AccountQueryRs", typeof(AccountQueryRq))]
    [XmlElement("AccountModRs", typeof(AccountModRq))]
    [XmlElement("AccountAddRs", typeof(AccountAddRq))]
    [XmlElement("CustomerQueryRs", typeof(CustomerQueryRq))]
    public List<QBRequest> Requests { get; set; } = [];

    public List<XElement> ToXElement(QBContext? context)
    {
        context ??= new QBContext();

        return Requests?.Select(r => r.ToXElement(context)).ToList() ?? [];
    }
}
