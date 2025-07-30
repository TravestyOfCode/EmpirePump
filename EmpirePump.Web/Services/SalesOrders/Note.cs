using EmpirePump.Web.QBSDK;
using System.Globalization;

namespace EmpirePump.Web.Services.SalesOrders;

public class Note
{
    public int Id { get; set; }
    public DateTime? NoteDateTime { get; set; }
    public string? Employee { get; set; }
    public required string NoteText { get; set; }
    // Relationship to a labor time used for getting quantity
    public int? LaborId { get; set; }

    public Note() { }
    public Note(string text)
    {
        // The text should have the first line with date, time and employee
        // and the remaining lines should be the note text.
        var lines = text.Split(Environment.NewLine);

        // Header should be formatted like "MM/dd/yyyy HH:MM tt by Employee Name"
        var header = lines[0].Split("by");
        NoteDateTime = DateTime.TryParseExact(header[0], "MM/dd/yyyy HH:mm tt", null, DateTimeStyles.AllowWhiteSpaces, out var d) ? d : null;
        Employee = header[1];

        NoteText = string.Join(Environment.NewLine, lines.Skip(1));
    }
}

internal static class NoteExtensions
{
    public static List<SalesOrderLineMod>? ToSalesOrderLineMod(this List<Note>? noteList)
    {
        throw new NotImplementedException();
    }
}
