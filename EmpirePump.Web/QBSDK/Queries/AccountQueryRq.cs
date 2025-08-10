using System.Xml.Linq;
using System.Xml.Serialization;

namespace EmpirePump.Web.QBSDK;

public class AccountQueryRq : ListQueryRq
{
    /// <summary>
    /// Filters according to the object's Name.
    /// </summary>
    public NameFilter? NameFilter { get; set; }

    /// <summary>
    /// Filters according to the object's Name.
    /// </summary>
    public NameRangeFilter? NameRangeFilter { get; set; }

    /// <summary>
    /// A list of QuickBooks account types to filter.
    /// </summary>
    public List<AccountType>? AccountType { get; set; }

    /// <summary>
    /// Filters by the specified currency. 
    /// </summary>
    public ListFilter? CurrencyFilter { get; set; }

    /// <summary>
    /// If the query was successful, this will contain a list of objects that
    /// match the queries filters. If no matches were found (StatusCode 500)
    /// the list will be empty. If there was an error with the query, the list
    /// will be null.
    /// </summary>
    [XmlElement("AccountRet")]
    public List<Account>? Results { get; set; }

    /// <summary>
    /// Converts the request into an XElement.
    /// </summary>
    /// <param name="context">The QBContext used to determine which fields are suppported.</param>
    /// <returns>An XElement representing the request.</returns>    
    public override XElement ToXElement(QBContext? context)
    {
        context ??= new QBContext();

        return new XElement(nameof(AccountQueryRq))
            .AddAttribute(requestID)
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
            .AddElement(CurrencyFilter)
            .AddElement(IncludeRetElement)
            .AddElement(OwnerID);
    }

    /// <summary>
    /// Parses the response for status information and response objects.
    /// </summary>
    /// <param name="response">The QBResponse to parse.</param>    
    internal override void ParseResponse(QBResponse? response)
    {
        var accountRs = response as AccountQueryRs;

        statusCode = accountRs?.StatusCode;
        statusSeverity = accountRs?.StatusSeverity;
        statusMessage = accountRs?.StatusMessage;
        retCount = accountRs?.ReturnedCount;
        Results = accountRs?.Accounts;
    }

    public static AccountQueryRq GetReconcilableAccounts() => new() { AccountType = [QBSDK.AccountType.Bank, QBSDK.AccountType.CreditCard] };


}
