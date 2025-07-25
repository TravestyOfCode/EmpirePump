using EmpirePump.Web.QBSDK.Enums;
using EmpirePump.Web.QBSDK.Transactions;
using EmpirePump.Web.QBSDK.Types;

namespace EmpirePump.Web.QBSDK.Commands;

public class InvoiceLineAdd
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
    public DateOnly? ServiceDate { get; set; }
    public ListRef? SalesTaxCodeRef { get; set; }
    public ListRef? OverrideItemAccountRef { get; set; }
    public string? Other1 { get; set; }
    public string? Other2 { get; set; }
    public List<LinkedTxn>? LinkToTxns { get; set; }
    public List<DataExt>? DataExtRets { get; set; }
}
