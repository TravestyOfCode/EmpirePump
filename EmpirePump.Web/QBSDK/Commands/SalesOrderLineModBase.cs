using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace EmpirePump.Web.QBSDK;

public abstract class SalesOrderLineModBase
{
    public string? TxnLineID { get; set; }
    public decimal? Quantity { get; set; }
    public string? UnitOfMeasure { get; set; }
    public ListRef? OverrideUOMSetRef { get; set; }

    public abstract XElement ToXElement(string name);
}

internal static class SalesOrderLineModBaseExtensions
{
    public static XElement AddElement(this XElement element, List<SalesOrderLineModBase>? values, [CallerArgumentExpression(nameof(values))] string name = "")
    {
        if (values != null)
        {
            foreach (var value in values)
            {
                element.Add(value.ToXElement(name));
            }
        }
        return element;
    }
}