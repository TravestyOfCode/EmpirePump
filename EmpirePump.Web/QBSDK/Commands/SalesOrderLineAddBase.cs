using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace EmpirePump.Web.QBSDK.Commands;

public abstract class SalesOrderLineAddBase
{

}

public static class SalesOrderLineAddBaseExtensions
{
    public static XElement AddElement(this XElement element, List<SalesOrderLineAddBase>? values, [CallerArgumentExpression(nameof(values))] string name = "")
    {
        if (values != null)
        {
            foreach (var value in values)
            {
                if (value is SalesOrderLineAdd sola)
                {
                    element.Add(sola.ToXElement());
                }
                if (value is SalesOrderLineGroupAdd solga)
                {
                    element.Add(solga.ToXElement());
                }
            }
        }
        return element;
    }
}