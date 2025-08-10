using System.Xml.Linq;
using System.Xml.Serialization;

namespace EmpirePump.Web.QBSDK;

public abstract class QBRequest : IQBXElement
{
    // A unique number assigned to requests when processing so we can match up
    // the correct response.
    internal int requestID;

    protected int? statusCode;
    /// <summary>
    /// A number that corresponds to a StatusSeverity and StatusMessage.
    /// </summary>
    [XmlIgnore]
    public int? StatusCode => statusCode;

    protected StatusSeverity? statusSeverity;
    /// <summary>
    /// One of the following values:
    /// INFO The request was completed, and the results are consistent with 
    /// what your application expected.
    /// WARNING The request was completed, but the results might not be 
    /// consistent with what you expected.
    /// ERROR The request was not completed. Response will contain no data.
    /// </summary>
    [XmlIgnore]
    public StatusSeverity? StatusSeverity => statusSeverity;

    protected string? statusMessage;
    /// <summary>
    /// An explanation of the success or error condition indicated by the 
    /// StatusCode.
    /// </summary>
    [XmlIgnore]
    public string? StatusMessage => statusMessage;

    /// <summary>
    /// Converts the request into an XElement representation.
    /// </summary>
    /// <param name="context">The QBContext used to exclude unsupported elements</param>
    /// <returns></returns>
    public abstract XElement ToXElement(QBContext? context);
}
