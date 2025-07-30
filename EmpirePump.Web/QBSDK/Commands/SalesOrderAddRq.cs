using System.Xml.Linq;
using System.Xml.Serialization;

namespace EmpirePump.Web.QBSDK;

public class SalesOrderAddRq : IQBXElement
{
    private int? statusCode;
    public int? StatusCode => statusCode;

    private StatusSeverity? statusSeverity;
    public StatusSeverity? StatusSeverity => statusSeverity;

    private string? statusMessage;
    public string? StatusMessage => statusMessage;

    public ListRef? CustomerRef { get; set; }

    public ListRef? ClassRef { get; set; }

    public ListRef? TemplateRef { get; set; }

    public DateOnly? TxnDate { get; set; }

    public string? RefNumber { get; set; }

    public Address? BillAddress { get; set; }

    public Address? ShipAddress { get; set; }

    public string? PONumber { get; set; }

    public ListRef? TermsRef { get; set; }

    public DateOnly? DueDate { get; set; }

    public ListRef? SalesRepRef { get; set; }

    public string? FOB { get; set; }

    public DateOnly? ShipDate { get; set; }

    public ListRef? ShipMethodRef { get; set; }

    public ListRef? ItemSalesTaxRef { get; set; }

    public bool? IsManuallyClosed { get; set; }

    public string? Memo { get; set; }

    public ListRef? CustomerMsgRef { get; set; }

    public bool? IsToBePrinted { get; set; }

    public bool? IsToBeEmailed { get; set; }

    public ListRef? CustomerSalesTaxCodeRef { get; set; }

    public string? Other { get; set; }

    public float? ExchangeRate { get; set; }

    public string? ExternalGUID { get; set; }

    public List<SalesOrderLineAddBase>? SalesOrderLines { get; set; }

    public SalesOrder? Ret { get; set; }

    /// <summary>
    /// Generates an XElement representation of the SalesOrderAddRq based on the QBContext supplied. Properties that
    /// are not supported by the QBContext are not included.
    /// </summary>
    /// <param name="context">The QBContext which contains the Edition and version of QB supported.</param>
    /// <returns>An XElement representing the SalesOrderAddRq.</returns>
    public XElement ToXElement(QBContext? context)
    {
        // TODO: Add CA/UK fields and test for version support when adding.
        context ??= new QBContext();

        var add = new XElement("SalesOrderAdd")
        .AddElement(CustomerRef)
        .AddElement(ClassRef)
        .AddElement(TemplateRef)
        .AddElement(TxnDate)
        .AddElement(RefNumber)
        .AddElement(BillAddress)
        .AddElement(ShipAddress)
        .AddElement(PONumber)
        .AddElement(TermsRef)
        .AddElement(DueDate)
        .AddElement(SalesRepRef)
        .AddElement(FOB)
        .AddElement(ShipDate)
        .AddElement(ShipMethodRef)
        .AddElement(ItemSalesTaxRef)
        .AddElement(IsManuallyClosed)
        .AddElement(Memo)
        .AddElement(CustomerMsgRef)
        .AddElement(IsToBePrinted)
        .AddElement(IsToBeEmailed)
        .AddElement(CustomerSalesTaxCodeRef)
        .AddElement(Other)
        .AddElement(ExchangeRate)
        .AddElement(ExternalGUID)
        .AddElement(SalesOrderLines);

        return new XElement(nameof(SalesOrderAddRq), add);
    }

    /// <summary>
    /// Sends the ItemQueryRq to QuickBooks to process.
    /// </summary>
    /// <param name="connection">The QuickBooks connection to process the request.</param>
    public void ProcessRequest(QBConnection connection)
    {
        // Set our default state to be an error.
        statusCode = -1;
        statusSeverity = QBSDK.StatusSeverity.ERROR;
        statusMessage = "Unknown error when processing the SalesOrderAddRq.";

        try
        {
            // Process the request to QB.
            var result = connection.ProcessRequest(this);
            if (result.WasSuccessful)
            {
                // We should have an SalesOrderAddRs element returned.
                var rs = result?.Value?.Root?.Element("QBXMLMsgsRs")?.Element("SalesOrderAddRs");
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
                    DeserializeRet(rs);
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
    /// Deserializes the response into a SalesOrder object.
    /// </summary>
    /// <param name="salesOrderAddRs">The query response to parse.</param>
    private void DeserializeRet(XElement salesOrderAddRs)
    {
        var soRet = salesOrderAddRs.Element("SalesOrderRet");
        if (soRet != null)
        {
            var ser = new XmlSerializer(typeof(SalesOrder));
            Ret = (SalesOrder?)ser.Deserialize(soRet.CreateReader());
        }
    }
}