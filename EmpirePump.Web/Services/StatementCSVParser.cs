using CsvHelper;
using CsvHelper.Configuration;
using EmpirePump.Web.Models.Reconcile;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.IO;

namespace EmpirePump.Web.Services;

public class StatementCSVParser
{
    // The default values are based on my bank csv file.

    // Does this file have a header and if so, which row. Non-zero based.
    public int? HeaderRow { get; set; } = 1;

    // Which row does the first transaction start on. Non-zero based.
    public int StartingRow { get; set; } = 2;

    // Which column is the transaction date. Non-zero based.
    public int TxnDateColumn { get; set; } = 1;

    // Which column is the description. Non-zero based.
    public int DescColumn { get; set; } = 5;

    // Does the statement have a single column for the amount, or separate
    // debit/credit columns?
    public bool IsSingleColumnAmount { get; set; } = false;

    // Which column is the debit column if not single column. Non-zero based.
    public int? DebitColumn { get; set; } = 6;

    // Which column is the credit column if not single column. Non-zero based.
    public int? CreditColumn { get; set; } = 7;

    // Which column is the amount column if single based. Non-zero based.
    public int? AmountColumn { get; set; } = null;

    // Which column is the check number column. Non-zero based
    public int? CheckNumberColumn { get; set; } = 8;

    public List<BankTransaction> ParseCSV(IFormFile statementFile)
    {
        // This is used to determine which row we are on so we can determine if
        // we need to use skip records to get to the header.
        int currentRow = 1;

        // Configure header row if applicable.
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = HeaderRow != null,
            ShouldSkipRecord = (lines) => HeaderRow != null && currentRow < HeaderRow.Value,
        };


        using var reader = new StreamReader(statementFile.OpenReadStream());
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        var records = new List<BankTransaction>();
        csv.Read(); // Should skip to our header if we have one.
        csv.ReadHeader(); // Should do nothing if we don't have a header.
        while (csv.Read())
        {
            var record = new BankTransaction()
            {
                TxnDate = csv.GetField<DateOnly>(TxnDateColumn - 1),
                Description = csv.GetField(DescColumn - 1),
                DebitAmount = DebitColumn.HasValue ? csv.GetField<decimal>(DebitColumn.Value - 1) : null,
                CreditAmount = CreditColumn.HasValue ? csv.GetField<decimal>(CreditColumn.Value - 1) : null,
                Amount = AmountColumn.HasValue ? csv.GetField<decimal>(AmountColumn.Value - 1) : 0,
                CheckNumber = CheckNumberColumn.HasValue ? csv.GetField(CheckNumberColumn.Value - 1) : null
            };
            records.Add(record);
        }

        return records;
    }
}
