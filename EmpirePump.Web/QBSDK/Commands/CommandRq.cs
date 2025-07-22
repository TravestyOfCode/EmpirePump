using EmpirePump.Web.QBSDK.Enums;
using EmpirePump.Web.QBSDK.Types;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace EmpirePump.Web.QBSDK.Commands;

public abstract class CommandRq<T> : QBRequest
{
    protected string? defMacro;
    public string? DefMacro { get => defMacro; set => defMacro = value; }

    public T? Result { get; protected set; }

    protected override void ParseResponse(XDocument doc)
    {
        var rs = doc.Root?.Element("QBXMLMsgsRs")?.Element(nameof(T));
        if (rs != null)
        {
            statusCode = int.TryParse(rs.Attribute(nameof(statusCode))?.Value, out var sc) ? sc : null;
            statusSeverity = Enum.TryParse<StatusSeverity>(rs.Attribute(nameof(statusCode))?.Value, out var ss) ? ss : null;
            statusMessage = rs.Attribute(nameof(statusCode))?.Value;

            Result = default;
            if (statusCode == 0)
            {
                var ser = new XmlSerializer(typeof(T));
                Result = (T?)ser.Deserialize(rs.FirstNode!.CreateReader());
            }
        }
    }
}
