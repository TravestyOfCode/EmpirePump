using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace EmpirePump.Web.QBSDK;

public class Address
{
    public string? Addr1 { get; set; }
    public string? Addr2 { get; set; }
    public string? Addr3 { get; set; }
    public string? Addr4 { get; set; }
    public string? Addr5 { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
    public string? Note { get; set; }

    public XElement ToXElement(string name = nameof(Address)) => new XElement(name)
        .AddElement(Addr1)
        .AddElement(Addr2)
        .AddElement(Addr3)
        .AddElement(Addr4)
        .AddElement(Addr5)
        .AddElement(City)
        .AddElement(State)
        .AddElement(PostalCode)
        .AddElement(Country)
        .AddElement(Note);
}

internal static class AddressExtensions
{
    public static XElement AddElement(this XElement element, Address? value, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        if (value != null)
        {
            element.Add(value.ToXElement(name));
        }
        return element;
    }
}