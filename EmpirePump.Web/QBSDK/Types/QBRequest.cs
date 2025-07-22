using EmpirePump.Web.QBSDK.Enums;
using System.Xml.Linq;

namespace EmpirePump.Web.QBSDK.Types;

public abstract class QBRequest
{
    protected int? statusCode;
    public int? StatusCode => statusCode;

    protected StatusSeverity? statusSeverity;
    public StatusSeverity? StatusSeverity => statusSeverity;

    protected string? statusMessage;
    public string? StatusMessage => statusMessage;

    protected OnError onError = OnError.stopOnError;
    public OnError OnError { get => onError; set => onError = value; }

    public abstract XElement ToXElement(QBContext? context);

    public virtual void ProcessRequest(QBConnection connection)
    {
        var result = connection.ProcessRequest(ToXElement(connection.QBContext));

        if (result.WasSuccessful)
        {
            ParseResponse(result.Value!);
        }
        else
        {
            statusCode = -1;
            statusSeverity = Enums.StatusSeverity.Error;
            statusMessage = result.StatusMessage;
        }
    }

    protected abstract void ParseResponse(XDocument doc);
}
