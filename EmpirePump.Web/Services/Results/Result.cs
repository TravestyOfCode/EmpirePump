using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace EmpirePump.Web.Services.Results;

public class Result
{
    public int StatusCode { get; set; }
    public required string StatusMessage { get; set; }
    public bool WasSuccessful => StatusCode >= 200 && StatusCode <= 299;
    public List<Error> Errors { get; } = [];

    [SetsRequiredMembers]
    public Result(int statusCode, string statusMessage)
    {
        StatusCode = statusCode;
        StatusMessage = statusMessage;
    }

    [SetsRequiredMembers]
    public Result(int statusCode, string statusMessage, IEnumerable<Error> errors) : this(statusCode, statusMessage)
    {
        Errors.AddRange(errors);
    }

    public static Result Ok() => new(200, "Ok");
    public static implicit operator Result(Error error) => new(error.ErrorCode, error.ErrorMessage, [error]);
}
