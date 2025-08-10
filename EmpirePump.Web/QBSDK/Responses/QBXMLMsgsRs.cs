using System.Xml.Serialization;

namespace EmpirePump.Web.QBSDK;

public class QBXMLMsgsRs
{
    [XmlElement("AccountQueryRs", typeof(AccountQueryRs))]
    public List<QBResponse> ResponseList { get; set; } = [];
}
