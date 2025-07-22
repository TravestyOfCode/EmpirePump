using EmpirePump.Web.QBSDK.Commands;
using EmpirePump.Web.QBSDK.Enums;
using EmpirePump.Web.QBSDK.Transactions;
using EmpirePump.Web.QBSDK.Types;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace EmpirePump.Web.QBSDK.Commands;

public class SalesOrderLineMod : SalesOrderLineModBase
{
    public string? TxnLineID { get; set; }
    public ListRef? ItemRef { get; set; }
    public string? Desc { get; set; }
    public decimal? Quantity { get; set; }
    public string? UnitOfMeasure { get; set; }
    public ListRef? OverrideUOMSetRef { get; set; }
    public decimal? Rate { get; set; }
    public decimal? RatePercent { get; set; }
    public ListRef? PriceLevelRef { get; set; }
    public ListRef? ClassRef { get; set; }
    public decimal? Amount { get; set; }
    public OptionForPriceRuleConflict? OptionForPriceRuleConflict { get; set; }
    public ListRef? InventorySiteRef { get; set; }
    public ListRef? InventorySiteLocationRef { get; set; }
    public string? SerialNumber { get; set; }
    public string? LotNumber { get; set; }
    public ListRef? SalesTaxCodeRef { get; set; }
    public bool? IsManuallyClosed { get; set; }
    public string? Other1 { get; set; }
    public string? Other2 { get; set; }

    public XElement ToXElement(string name = nameof(SalesOrderLineMod))
    {
        return new XElement(name)
            .AddElement(TxnLineID)
            .AddElement(ItemRef)
            .AddElement(Desc)
            .AddElement(Quantity)
            .AddElement(UnitOfMeasure)
            .AddElement(Rate)
            .AddElement(RatePercent)
            .AddElement(PriceLevelRef)
            .AddElement(ClassRef)
            .AddElement(Amount)
            .AddElement(OptionForPriceRuleConflict)
            .AddElement(InventorySiteRef)
            .AddElement(InventorySiteLocationRef)
            .AddElement(SerialNumber)
            .AddElement(LotNumber)
            .AddElement(SalesTaxCodeRef)
            .AddElement(IsManuallyClosed)
            .AddElement(Other1)
            .AddElement(Other2);
    }
}

public static class SalesOrderLineModExtensions
{
    public static XElement AddElement(this XElement element, List<SalesOrderLineMod>? values, [CallerArgumentExpression(nameof(values))] string name = "")
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

    public static SalesOrderLineMod ToMod(this SalesOrderLine sol)
    {
        return new SalesOrderLineMod()
        {
            TxnLineID = sol.TxnLineID,
            ItemRef = sol.Item,
            Desc = sol.Desc,
            Quantity = sol.Quantity,
            UnitOfMeasure = sol.UnitOfMeasure,
            OverrideUOMSetRef = sol.OverrideUOMSet,
            Rate = sol.Rate,
            RatePercent = sol.RatePercent,
            //PriceLevelRef= sol.PriceLevel
            ClassRef = sol.Class,
            Amount = sol.Amount,
            //OptionForPriceRuleConflict= sol.
            InventorySiteRef = sol.InventorySite,
            InventorySiteLocationRef = sol.InventorySiteLocation,
            SerialNumber = sol.SerialNumber,
            LotNumber = sol.LotNumber,
            SalesTaxCodeRef = sol.SalesTaxCode,
            IsManuallyClosed = sol.IsManuallyClosed,
            Other1 = sol.Other1,
            Other2 = sol.Other2
        };
    }

    public static List<SalesOrderLineMod>? ToMod(this List<SalesOrderLine>? sol)
    {
        return sol?.Select(s => s.ToMod()).ToList();
    }
}

