using System.Xml.Serialization;

namespace EmpirePump.Web.QBSDK;

public class QBXML
{
    /// <summary>
    /// Determines if QuickBooks should process any remaining requests if it
    /// encounters an error when processing a request. Default is stopOnError.
    /// </summary>
    public OnError OnError { get; set; }

    private QBContext context = new QBContext();

    /// <summary>
    /// A list of all the requests to send to QuickBooks.
    /// </summary>
    [XmlElement("QBXMLMsgsRs")]
    public QBXMLRequestList? QBXMLMsgs { get; set; }

    public override string ToString()
    {
        return $"<?xml version=\"1.0\" encoding=\"utf-16\" ?><?qbxml version=\"{context.MajorVersion}.{context.MinorVersion}\" ?><QBXML><QBXMLMsgsRq onError=\"{OnError}\">{QBXMLMsgs?.ToXElement(context)}</QBXMLMsgsRq></QBXML>";
    }
}
