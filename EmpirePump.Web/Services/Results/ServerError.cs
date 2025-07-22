using System.Diagnostics.CodeAnalysis;

namespace EmpirePump.Web.Services.Results;

public class ServerError : Error
{
    [SetsRequiredMembers]
    public ServerError() : this("Server Error") { }

    [SetsRequiredMembers]
    public ServerError(string message) : base(500, message) { }
}