using System.Xml.Linq;

namespace EmpirePump.Web.QBSDK;

public class TransactionTypeFilter : IToXElement
{
    public required List<TxnType> TxnTypeFilter { get; set; }

    public XElement ToXElement(string name = nameof(TransactionTypeFilter)) => new XElement(name)
        .AddElement(TxnTypeFilter);
}