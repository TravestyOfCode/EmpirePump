using EmpirePump.Web.QBSDK;
using EmpirePump.Web.QBSDK.Commands;
using EmpirePump.Web.QBSDK.Enums;
using EmpirePump.Web.QBSDK.Types;
using System.Xml.Linq;

namespace EmpirePump.Web.QBSDK.Commands;

public class SalesOrderLineAdd : SalesOrderLineAddBase
{
    public ListRef? ItemRef { get; set; }
    public string? Desc { get; set; }
    public decimal? Quantity { get; set; }
    public string? UnitOfMeasure { get; set; }
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
    public List<DataExt>? DataExts { get; set; }

    public XElement ToXElement(string name = nameof(SalesOrderLineAdd))
    {
        return new XElement(name)
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
            .AddElement(Other2)
            .AddElement(DataExts, nameof(DataExt));
    }
}

