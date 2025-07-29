using System.Diagnostics.CodeAnalysis;

namespace EmpirePump.Web.Services.Results;

public class Error
{
    public int ErrorCode { get; set; }
    public required string ErrorMessage { get; set; }
    public Dictionary<string, List<string>> ModelState { get; } = [];

    [SetsRequiredMembers]
    public Error(int errorCode, string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);

        ErrorCode = errorCode;

        ErrorMessage = errorMessage;
    }

    public static Error BadRequest() => new BadRequestError();
    public static Error BadRequest(string key, string message) => new BadRequestError(key, message);
    public static Error Forbidden() => new ForbiddenError();
    public static Error NotFound() => new NotFoundError();
    public static Error NotFound(string key) => new NotFoundError($"The value was not found for '{key}'");
    public static Error NotFound(string key, string value) => new NotFoundError($"The value '{value}' was not found for '{key}'.");
    public static Error ServerError() => new ServerError();
    public static Error ServerError(string message) => new ServerError(message);
}
