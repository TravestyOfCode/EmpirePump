using System.Xml.Serialization;

namespace EmpirePump.Web.QBSDK;

public abstract class IterableListQueryRq : ListQueryRq
{
    protected int? iteratorRemainingCount;
    /// <summary>
    /// Indicates the approximate number of objects remaining in the iteration.
    /// It is not guaranteed to be exact due to new object creation/deletion. 
    /// </summary>
    [XmlIgnore]
    public int? RemainingCount => iteratorRemainingCount;

    // Used to start or continue an iteration query.
    // TODO: We may need to keep the connection open so iterators
    // will work. I think if we close the connection like we have been
    // doing it will invalidate any iterators.
    protected Iterator? iterator;

    // The ID of the iterator that needs to be passed in the query to 
    // continue. It will be returned from a query where the iterator
    // was set to Start and has a MaxReturned value.
    protected string? iteratorID;
}
