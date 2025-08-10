using System.Xml.Serialization;

namespace EmpirePump.Web.QBSDK;

public abstract class ListQueryRq : QBRequest
{
    protected MetaData? metaData;
    /// <summary>
    /// This is used in a query to cause a count of query objects to be 
    /// returned. You can specify that the count of query objects is to be 
    /// returned with the returned objects, or you can specify that only a 
    /// count and no data is returned. 
    /// </summary>
    [XmlIgnore]
    public MetaData? MetaData { get => metaData; set => metaData = value; }

    protected int? retCount;
    /// <summary>
    /// Contains the approximate count of the objects that could be expected 
    /// to be returned from the query. It is not guaranteed to be exact due to
    /// new object creation/deletion. It is returned in a query if in the query
    /// request you specified the metaData attribute with a value of 
    /// MetaDataOnly or MetaDataAndResponseData.
    /// </summary>
    [XmlIgnore]
    public int? ReturnedCount => retCount;

    /// <summary>
    /// A List of ListID values to filter. ListIDs are not unique across lists
    /// but is unique across each particular type of list.
    /// </summary>
    public List<string>? ListID { get; set; }

    /// <summary>
    /// A List of FullName values to filter. A FullName may not be unique 
    /// across lists but is unique across each particular type of list.
    /// </summary>
    public List<string>? FullName { get; set; }

    /// <summary>
    /// Limits the number of objects that a query returns.
    /// </summary>
    public int? MaxReturned { get; set; }

    /// <summary>
    /// Used to select list objects based on whether or not they are currently
    /// enabled for use by QuickBooks. By default will return only active
    /// objects if null or empty.
    /// </summary>
    public List<ActiveStatus>? ActiveStatus { get; set; }

    /// <summary>
    /// Selects objects modified on or after this date. The value must be 
    /// between 1970-01-01 and 2038-01-19T03:14:07. If FromModifiedDate 
    /// includes a date but not a time the time is assumed to be 
    /// zero.
    /// </summary>
    public DateTime? FromModifiedDate { get; set; }

    /// <summary>
    /// Selects objects modified on or before this date. The value must be 
    /// between 1970-01-01 and 2038-01-19T03:14:07. If ToModifiedDate includes
    /// a date but not a time the time is assumed to be zero.
    /// </summary>
    public DateTime? ToModifiedDate { get; set; }

    /// <summary>
    /// Limits the data that will be returned in the response. In this list,
    /// you specify the name of each top-level element or aggregate that you 
    /// want to be returned in the response to the request.
    /// </summary>
    public List<string>? IncludeRetElement { get; set; }

    /// <summary>
    /// Zero or more OwnerID values. OwnerID refers to the owner of a data
    /// extension. If OwnerID is 0, this is a public data extension, also known
    /// as a custom field which appear in the QuickBooks UI.
    /// If OwnerID is a GUID, this field is a private data extension defined
    /// by an integrated application which do not appear in the QuickBooks UI.
    /// </summary>
    public List<string>? OwnerID { get; set; }
}
