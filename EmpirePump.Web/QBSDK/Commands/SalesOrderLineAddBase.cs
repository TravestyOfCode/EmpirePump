using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace EmpirePump.Web.QBSDK;

public abstract class SalesOrderLineAddBase
{
    public decimal? Quantity { get; set; }
    public string? UnitOfMeasure { get; set; }
    public ListRef? InventorySiteRef { get; set; }
    public ListRef? InventorySiteLocationRef { get; set; }
    public List<DataExt>? DataExt { get; set; }

    public abstract XElement ToXElement(string name);
}

internal static class SalesOrderLineAddBaseExtensions
{
    public static XElement AddElement(this XElement element, List<SalesOrderLineAddBase>? values, [CallerArgumentExpression(nameof(values))] string name = "")
    {
        if (values != null)
        {
            foreach (var line in values)
            {
                element.Add(line.ToXElement(name));
            }
        }
        return element;
    }
}