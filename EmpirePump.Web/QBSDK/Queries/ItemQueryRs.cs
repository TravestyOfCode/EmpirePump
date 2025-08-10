using System.Xml.Linq;
using System.Xml.Serialization;

namespace EmpirePump.Web.QBSDK;

public class ItemQueryRq : IQBXElement
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

    public string? ListID { get; set; }

    public string? FullName { get; set; }

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

    public ActiveStatus? ActiveStatus { get; set; }

    public DateTime? FromModifiedDate { get; set; }

    public DateTime? ToModifiedDate { get; set; }

    public NameFilter? NameFilter { get; set; }

    public NameRangeFilter? NameRangeFilter { get; set; }

    public string? IncludeRetElement { get; set; }

    public string? OwnerID { get; set; }

    public ItemType? ItemType { get; set; }

    public List<Item>? RetList { get; internal set; }


    /// <summary>
    /// Generates an XElement representation of the ItemQueryRq based on the QBContext supplied. Properties that
    /// are not supported by the QBContext are not included.
    /// </summary>
    /// <param name="context">The QBContext which contains the Edition and version of QB supported.</param>
    /// <returns>An XElement representing the ItemQueryRq.</returns>
    public XElement ToXElement(QBContext? context = default)
    {
        context ??= new QBContext();

        return new XElement(nameof(ItemQueryRq))
            .AddAttributeIf(context.Supports(QBEdition.Any, 4, 0), metaData)
            .AddAttributeIf(context.Supports(QBEdition.Any, 5, 0), iterator)
            .AddAttributeIf(context.Supports(QBEdition.Any, 5, 0), iteratorID)
            .AddElement(ListID)
            .AddElement(FullName)
            .AddElement(MaxReturned)
            .AddElement(ActiveStatus)
            .AddElement(FromModifiedDate)
            .AddElement(ToModifiedDate)
            .AddElement(NameFilter)
            .AddElement(NameRangeFilter)
            .AddElementIf(context.Supports(QBEdition.Any, 4, 0), IncludeRetElement)
            .AddElementIf(context.Supports(QBEdition.Any, 2, 0), OwnerID);
    }

    /// <summary>
    /// Sends the ItemQueryRq to QuickBooks to process.
    /// </summary>
    /// <param name="connection">The QuickBooks connection to process the request.</param>
    public void ProcessRequest(QBConnection connection)
    {
        // Set our default state to be an error.
        statusCode = -1;
        statusSeverity = QBSDK.StatusSeverity.Error;
        statusMessage = "Unknown error when processing the ItemQueryRq.";

        try
        {
            // Process the request to QB.
            var result = connection.ProcessRequest(this);
            if (result.WasSuccessful)
            {
                // We should have an ItemQueryRs element returned.
                var rs = result?.Value?.Root?.Element("QBXMLMsgsRs")?.Element("ItemQueryRs");
                if (rs == null)
                {
                    statusMessage = "Request was processed, but was unable to get the response.";
                    return;
                }

                // Get the status from the Rs attributes
                statusCode = int.TryParse(rs.Attribute(nameof(statusCode))?.Value, out var code) ? code : statusCode;
                statusSeverity = Enum.TryParse<StatusSeverity>(rs.Attribute(nameof(statusSeverity))?.Value, out var sev) ? sev : statusSeverity;
                statusMessage = rs.Attribute(nameof(statusMessage))?.Value;

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
    /// Deserializes the response list into a list of Items.
    /// </summary>
    /// <param name="itemQueryRs">The query response to parse.</param>
    private void DeserializeRetList(XElement itemQueryRs)
    {
        var ser = new XmlSerializer(typeof(ItemList));
        if (ItemType != null)
        {
            string name = $"Item{ItemType}Ret";
            foreach (var item in itemQueryRs.Elements().Reverse())
            {
                if (!item.Name.LocalName.Equals(name))
                {
                    item.Remove();
                }
            }
        }
        var list = (ItemList?)ser.Deserialize(itemQueryRs.CreateReader());
        if (list != null)
        {
            RetList = list.RetList;
        }
    }
}

