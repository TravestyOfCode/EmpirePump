using System.Xml.Serialization;

namespace EmpirePump.Web.QBSDK;

public abstract class QBResponse
{
    [XmlAttribute("statusCode")]
    public int StatusCode { get; set; }

    [XmlAttribute("statusSeverity")]
    public StatusSeverity StatusSeverity { get; set; }

    [XmlAttribute("statusMessage")]
    public string? StatusMessage { get; set; }

    [XmlAttribute("requestID")]
    public int RequestID { get; set; }
}
