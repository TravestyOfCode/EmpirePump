using System.Xml.Linq;
using System.Xml.Serialization;

namespace EmpirePump.Web.QBSDK;

public class TransactionQueryRq : IQBXElement
{
    private int? statusCode;
    public int? StatusCode => statusCode;

    private StatusSeverity? statusSeverity;
    public StatusSeverity? StatusSeverity => statusSeverity;

    private string? statusMessage;
    public string? StatusMessage => statusMessage;

    private MetaData? metaData;
    public MetaData? MetaData { get => metaData; set => metaData = value; }

    private Iterator? iterator;

    private string? iteratorID;

    private int? retCount;
    public int? ReturnedCount => retCount;

    private int? iteratorRemainingCount;
    public int? RemainingCount => iteratorRemainingCount;

    public string? TxnID { get; set; }

    private int? _MaxReturned;
    public int? MaxReturned
    {
        get => _MaxReturned;
        set
        {
            switch (value)
            {
                case <= 0:
                    {
                        throw new InvalidOperationException("Unable to set MaxReturned to less than 1.");
                    }
                case > 0:
                    {
                        if (iteratorID != null) iterator = Iterator.Continue;
                        else iterator = Iterator.Start;
                    }
                    break;
                case null:
                    {
                        iterator = null;
                        iteratorID = null;
                    }
                    break;
            }
            _MaxReturned = value;
        }
    }

    public List<string>? RefNumber { get; set; }

    public List<string>? RefNumberCaseSensitive { get; set; }

    public RefNumberFilter? RefNumberFilter { get; set; }

    public StringRangeFilter? RefNumberRangeFilter { get; set; }

    public DateRangeFilter? TransactionModifiedDateRangeFilter { get; set; }

    public DateRangeFilter? TransactionDateRangeFilter { get; set; }

    public TransactionFilter<EntityType>? TransactionEntityFilter { get; set; }

    public TransactionFilter<AccountType>? TransactionAccountFilter { get; set; }

    public TransactionFilter<ItemType>? TransactionItemFilter { get; set; }

    public ListTreeFilter? TransactionClassFilter { get; set; }

    public TransactionTypeFilter? TransactionTypeFilter { get; set; }

    public TransactionDetailLevel? TransactionDetailLevelFilter { get; set; }

    public TransactionPostingStatus? TransactionPostingStatusFilter { get; set; }

    public TransactionPaidStatus? TransactionPaidStatusFilter { get; set; }

    public ListFilter? CurrencyFilter { get; set; }

    public string? IncludeRetElement { get; set; }

    public List<Transaction>? RetList { get; internal set; }

    /// <summary>
    /// Generates an XElement representation of the TransactionQueryRq based on the QBContext supplied. Properties that
    /// are not supported by the QBContext are not included.
    /// </summary>
    /// <param name="context">The QBContext which contains the Edition and version of QB supported.</param>
    /// <returns>An XElement representing the TransactionQueryRq.</returns>
    public XElement ToXElement(QBContext? context)
    {
        context ??= new QBContext();

        if (!context.Supports(QBEdition.Any, 4, 0))
        {
            throw new InvalidOperationException($"QB Version {context} must be greater than 4.0 to support TransactionQueryRq.");
        }

        return new XElement(nameof(TransactionQueryRq))
            .AddAttributeIf(context.Supports(QBEdition.Any, 4, 0), metaData)
            .AddAttributeIf(context.Supports(QBEdition.Any, 5, 0), iterator)
            .AddAttributeIf(context.Supports(QBEdition.Any, 5, 0), iteratorID)
            .AddElement(TxnID)
            .AddElement(MaxReturned)
            .AddElement(RefNumber)
            .AddElementIf(context.Supports(QBEdition.Any, 4, 0), RefNumberCaseSensitive)
            .AddElement(RefNumberFilter)
            .AddElement(RefNumberRangeFilter, "RefNumber")
            .AddElement(TransactionModifiedDateRangeFilter, "TransactionModified")
            .AddElement(TransactionDateRangeFilter, "TransactionDate")
            .AddElement(TransactionEntityFilter)
            .AddElement(TransactionAccountFilter)
            .AddElement(TransactionItemFilter)
            .AddElement(TransactionClassFilter)
            .AddElement(TransactionTypeFilter)
            .AddElement(TransactionDetailLevelFilter)
            .AddElement(TransactionPostingStatusFilter)
            .AddElement(TransactionPaidStatusFilter)
            .AddElementIf(context.Supports(QBEdition.Any, 8, 0), CurrencyFilter)
            .AddElement(IncludeRetElement);
    }

    /// <summary>
    /// Sends the TransactionQueryRq to QuickBooks to process.
    /// </summary>
    /// <param name="connection">The QuickBooks connection to process the request.</param>
    public void ProcessRequest(QBConnection connection)
    {
        // Set our default state to be an error.
        statusCode = -1;
        statusSeverity = QBSDK.StatusSeverity.ERROR;
        statusMessage = "Unknown error when processing the TransactionQueryRq.";

        try
        {
            // Process the request to QB.
            var result = connection.ProcessRequest(this);
            if (result.WasSuccessful)
            {
                // We should have an TransactionQueryRs element returned.
                var rs = result?.Value?.Root?.Element("QBXMLMsgsRs")?.Element("TransactionQueryRs");
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
                iteratorRemainingCount = int.TryParse(rs.Attribute(nameof(iteratorRemainingCount))?.Value, out var rem) ? rem : null;
                iteratorID = rs.Attribute(nameof(iteratorID))?.Value;
                iterator = iteratorRemainingCount > 0 ? Iterator.Continue : null;

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
    /// Deserializes the response list into a list of Transactions.
    /// </summary>
    /// <param name="transactionQueryRs">The query response to parse.</param>
    private void DeserializeRetList(XElement transactionQueryRs)
    {
        var ser = new XmlSerializer(typeof(TransactionList));
        var list = (TransactionList?)ser.Deserialize(transactionQueryRs.CreateReader());
        if (list != null)
        {
            RetList = list.RetList;
        }
    }

    // Static Query Functions
    public static TransactionQueryRq GetByAccountIDAndDateRange(string accountID, DateOnly fromDate, DateOnly toDate) => new()
    {
        TransactionAccountFilter = new() { ListID = [accountID] },
        TransactionDateRangeFilter = new() { From = fromDate, To = toDate }
    };
}
