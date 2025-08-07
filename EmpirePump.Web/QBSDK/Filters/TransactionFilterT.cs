using System.Xml.Linq;

namespace EmpirePump.Web.QBSDK;

public class TransactionFilter<T> : ListTreeFilter, IToXElement where T : struct, Enum
{
    public T? Filter { get; set; }

    public new XElement ToXElement(string name = nameof(TransactionFilter<T>)) => new XElement(name)
        .AddElement(Filter, $"{typeof(T).Name}Filter")
        .AddElement(ListID)
        .AddElement(FullName)
        .AddElement(ListIDWithChildren)
        .AddElement(FullNameWithChildren);
}