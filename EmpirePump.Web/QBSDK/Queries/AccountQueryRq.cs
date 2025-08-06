using System.Xml.Linq;
using System.Xml.Serialization;

namespace EmpirePump.Web.QBSDK;

public class AccountQueryRq : IQBXElement
{
    private int? statusCode;
    public int? StatusCode => statusCode;

    private StatusSeverity? statusSeverity;
    public StatusSeverity? StatusSeverity => statusSeverity;

    private string? statusMessage;
    public string? StatusMessage => statusMessage;

    private MetaData? metaData;
    public MetaData? MetaData { get => metaData; set => metaData = value; }

    private int? retCount;
    public int? ReturnedCount => retCount;

    public string? ListID { get; set; }

    public string? FullName { get; set; }

    public int? MaxReturned { get; set; }

    public ActiveStatus? ActiveStatus { get; set; }

    public DateTime? FromModifiedDate { get; set; }

    public DateTime? ToModifiedDate { get; set; }

    public NameFilter? NameFilter { get; set; }

    public NameRangeFilter? NameRangeFilter { get; set; }

    public List<AccountType>? AccountType { get; set; }

    public ListFilter? CurrencyFilter { get; set; }

    public string? IncludeRetElement { get; set; }

    public string? OwnerID { get; set; }

    public List<Account>? RetList { get; set; }

    /// <summary>
    /// Generates an XElement representation of the AccountQueryRq based on the QBContext supplied. Properties that
    /// are not supported by the QBContext are not included.
    /// </summary>
    /// <param name="context">The QBContext which contains the Edition and version of QB supported.</param>
    /// <returns>An XElement representing the AccountQueryRq.</returns>
    public XElement ToXElement(QBContext? context)
    {
        context ??= new QBContext();

        return new XElement(nameof(AccountQueryRq))
            .AddAttributeIf(context.Supports(QBEdition.Any, 4, 0), metaData)
            .AddElement(ListID)
            .AddElement(FullName)
            .AddElement(MaxReturned)
            .AddElement(ActiveStatus)
            .AddElement(FromModifiedDate)
            .AddElement(ToModifiedDate)
            .AddElement(NameFilter)
            .AddElement(NameRangeFilter)
            .AddElement(AccountType)
            .AddElementIf(context.Supports(QBEdition.Any, 8, 0), CurrencyFilter)
            .AddElementIf(context.Supports(QBEdition.Any, 4, 0), IncludeRetElement)
            .AddElementIf(context.Supports(QBEdition.Any, 2, 0), OwnerID);
    }

    /// <summary>
    /// Sends the AccountQueryRq to QuickBooks to process.
    /// </summary>
    /// <param name="connection">The QuickBooks connection to process the request.</param>
    public void ProcessRequest(QBConnection connection)
    {
        // Set our default state to be an error.
        statusCode = -1;
        statusSeverity = QBSDK.StatusSeverity.ERROR;
        statusMessage = "Unknown error when processing the AccountQueryRq.";

        try
        {
            // Process the request to QB.
            var result = connection.ProcessRequest(this);
            if (result.WasSuccessful)
            {
                // We should have an AccountQueryRs element returned.
                var rs = result?.Value?.Root?.Element("QBXMLMsgsRs")?.Element("AccountQueryRs");
                if (rs == null)
                {
                    statusMessage = "Request was processed, but was unable to get the response.";
                    return;
                }

                // Get the status from the Rs attributes
                statusCode = int.TryParse(rs.Attribute(nameof(statusCode))?.Value, out var code) ? code : statusCode;
                statusSeverity = Enum.TryParse<StatusSeverity>(rs.Attribute(nameof(statusSeverity))?.Value, out var sev) ? sev : statusSeverity;
                statusMessage = rs.Attribute(nameof(statusMessage))?.Value;
                retCount = int.TryParse(rs.Attribute(nameof(retCount))?.Value, out var ret) ? ret : null;

                if (statusCode == 0)
                {
                    DeserializeRetList(rs);
                }
                return;
            }
            statusCode = result?.StatusCode ?? statusCode;
            statusMessage = result?.StatusMessage ?? statusMessage;
        }
        catch (Exception ex)
        {
            statusCode = -1;
            statusMessage = ex.Message;
        }
    }

    /// <summary>
    /// Deserializes the response list into a list of Accounts.
    /// </summary>
    /// <param name="accountQueryRs">The query response to parse.</param>
    private void DeserializeRetList(XElement accountQueryRs)
    {
        var ser = new XmlSerializer(typeof(AccountList));
        var list = (AccountList?)ser.Deserialize(accountQueryRs.CreateReader());
        if (list != null)
        {
            RetList = list.RetList;
        }
    }

    public static AccountQueryRq GetReconcilableAccounts(ActiveStatus? activeStatus = null)
    {
        return new AccountQueryRq()
        {
            ActiveStatus = activeStatus,
            AccountType = [QBSDK.AccountType.Bank, QBSDK.AccountType.CreditCard]
        };
    }
}