using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace EmpirePump.Web.QBSDK;

public class SalesOrderLineMod : SalesOrderLineModBase
{
    public ListRef? ItemRef { get; set; }
    public string? Desc { get; set; }
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

    public override XElement ToXElement(string name = nameof(SalesOrderLineMod))
    {
        return new XElement(nameof(SalesOrderLineMod))
        .AddElement(TxnLineID)
        .AddElement(ItemRef)
        .AddElement(Desc)
        .AddElement(Quantity)
        .AddElement(UnitOfMeasure)
        .AddElement(OverrideUOMSetRef)
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

internal static class SalesOrderLineModExtensions
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

    public static SalesOrderLineMod ToModRq(this SalesOrderLine line)
    {
        return new SalesOrderLineMod()
        {
            TxnLineID = line.TxnLineID,
            ItemRef = line.Item,
            Desc = line.Desc,
            Quantity = line.Quantity,
            UnitOfMeasure = line.UnitOfMeasure,
            OverrideUOMSetRef = line.OverrideUOMSet,
            Rate = line.Rate,
            RatePercent = line.RatePercent,
            ClassRef = line.Class,
            Amount = line.Amount,
            InventorySiteLocationRef = line.InventorySiteLocation,
            InventorySiteRef = line.InventorySite,
            SerialNumber = line.SerialNumber,
            LotNumber = line.LotNumber,
            SalesTaxCodeRef = line.SalesTaxCode,
            IsManuallyClosed = line.IsManuallyClosed,
            Other1 = line.Other1,
            Other2 = line.Other2
        };
    }

    public static List<SalesOrderLineMod>? ToModRq(this List<SalesOrderLine>? lines)
    {
        return lines?.Select(l => l.ToModRq()).ToList();
    }
}