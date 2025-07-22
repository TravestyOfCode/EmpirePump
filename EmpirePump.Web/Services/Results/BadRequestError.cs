using System.Diagnostics.CodeAnalysis;

namespace EmpirePump.Web.Services.Results;

public class BadRequestError : Error
{
    [SetsRequiredMembers]
    public BadRequestError() : this("Bad Request") { }

    [SetsRequiredMembers]
    public BadRequestError(string message) : base(400, message) { }

    [SetsRequiredMembers]
    public BadRequestError(string property, string message) : this("Bad Request")
    {
        if (ModelState.TryGetValue(property, out var list))
        {
            list.Add(message);
        }
        else
        {
            ModelState[property] = [message];
        }
    }
}