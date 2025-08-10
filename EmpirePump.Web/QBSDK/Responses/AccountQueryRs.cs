using System.Xml.Serialization;

namespace EmpirePump.Web.QBSDK;

public class AccountQueryRs : QBResponse
{
    [XmlAttribute("retCount")]
    public int ReturnedCount { get; set; }

    [XmlElement("AccountRet")]
    public List<Account>? Accounts { get; set; }
}
