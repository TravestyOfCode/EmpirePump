using EmpirePump.Web.QBSDK.Transactions;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace EmpirePump.Web.QBSDK.Commands;

public abstract class SalesOrderLineModBase
{

}

public static class SalesOrderLineModBaseExtensions
{
    public static XElement AddElement(this XElement element, List<SalesOrderLineModBase>? values, [CallerArgumentExpression(nameof(values))] string name = "")
    {
        if (values != null)
        {
            foreach (var value in values)
            {
                if (value is SalesOrderLineMod solm)
                {
                    element.Add(solm.ToXElement());
                }
                if (value is SalesOrderLineGroupMod solgm)
                {
                    element.Add(solgm.ToXElement());
                }
            }
        }
        return element;
    }

    public static List<SalesOrderLineModBase>? ToMod(this List<SalesOrderLineBase>? lines)
    {
        if (lines == null)
        {
            return null;
        }

        var result = new List<SalesOrderLineModBase>();
        foreach (var line in lines)
        {
            if (line is SalesOrderLine sol)
            {
                result.Add(sol.ToMod());
            }
            else if (line is SalesOrderLineGroup solg)
            {
                result.Add(solg.ToMod());
            }
        }
        return result;
    }
}