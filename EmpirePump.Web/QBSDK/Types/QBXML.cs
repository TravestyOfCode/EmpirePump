using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace EmpirePump.Web.QBSDK;

public class QBXML
{
    // Used to add request id to our requests so we can match up to responses.
    private int _currentRequestID = 1;

    private OnError onError = OnError.stopOnError;
    /// <summary>
    /// Determines if QuickBooks should process any remaining requests if it
    /// encounters an error when processing a request. Default is stopOnError.
    /// </summary>
    public OnError OnError { get => onError; set => onError = value; }

    private QBContext _context = new QBContext();

    /// <summary>
    /// A list of all the requests to send to QuickBooks.
    /// </summary>
    private List<QBRequest> _requests = [];
    public IReadOnlyCollection<QBRequest> Requests => _requests.AsReadOnly();

    /// <summary>
    /// Adds a QBRequest to the request list.
    /// </summary>
    /// <param name="request">The QBRequest to add to the request list.</param>
    public void AddRequest(QBRequest request)
    {
        request.requestID = _currentRequestID++;
        _requests.Add(request);
    }

    /// <summary>
    /// Removes the request from the request list.
    /// </summary>
    /// <param name="requestID">The RequestID of the request to remove. The 
    /// RequestID is populated when the request is added to the request list.</param>
    public void RemoveRequest(int requestID)
    {
        var rq = _requests.Where(r => r.requestID == requestID).SingleOrDefault();
        if (rq != null)
        {
            _requests.Remove(rq);
        }
    }

    /// <summary>
    /// Removes all the requests from the request list.
    /// </summary>
    public void ClearRequests()
    {
        _requests = [];
        _currentRequestID = 1;
    }

    /// <summary>
    /// Sends all of the requests in the request list to QuickBooks to process.
    /// </summary>
    /// <param name="connection">The QuickBooks connection to used to process.</param>
    public void ProcessRequests(QBConnection connection)
    {
        _context = connection.QBContext;

        var response = connection.ProcessRequest(ToString());

        if (response.WasSuccessful)
        {
            // Response.Value should never be null if response.WasSuccessful
            var doc = XDocument.Parse(response.Value!);

            // We should always have a QBXMLMsgsRs element in our document.
            var reader = doc?.Root?.Element(nameof(QBXMLMsgsRs))?.CreateReader() ?? throw new InvalidOperationException("Unable to get QBXMLMsgsRs reader.");

            // Deserialize all of the responses
            var ser = new XmlSerializer(typeof(QBXMLMsgsRs));
            var msgsRs = (QBXMLMsgsRs?)ser.Deserialize(reader) ?? throw new InvalidOperationException("Unable to deserialize QBXMLMsgsRs.");

            // Have the request process the response matching based on the requestID
            foreach (var request in _requests)
            {
                request.ParseResponse(msgsRs.ResponseList.Where(r => r.RequestID == request.requestID).SingleOrDefault());
            }
        }
        else
        {
            throw new InvalidOperationException($"Unable to process request. Error was: {response.StatusMessage}");
        }
    }

    /// <summary>
    /// Generates an XDocument based on the requests in the request list.
    /// </summary>
    /// <returns>An XDocument representing the requests.</returns>
    public XDocument ToXDocument()
    {
        var doc = new XDocument(new XProcessingInstruction("qbxml", $"version=\"{_context.MajorVersion}.{_context.MinorVersion}\""));
        var qbxmlMsgsRq = new XElement("QBXMLMsgsRq", new XAttribute(nameof(onError), onError));
        foreach (var request in _requests)
        {
            qbxmlMsgsRq.Add(request.ToXElement(_context));
        }
        doc.Add(new XElement(nameof(QBXML), qbxmlMsgsRq));
        return doc;
    }

    public override string ToString()
    {
        using StringWriter writer = new StringWriter();
        var doc = ToXDocument();
        doc.Save(writer, SaveOptions.None);
        return writer.ToString();
    }


}
