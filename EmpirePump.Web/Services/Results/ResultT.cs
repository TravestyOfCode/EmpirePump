using System;
using System.Diagnostics.CodeAnalysis;

namespace EmpirePump.Web.Services.Results;

public class Result<T> : Result
{
    private readonly T? _Value;
    public T? Value
    {
        get => WasSuccessful ? _Value : throw new InvalidOperationException("Unable to access Value of Result when Result has Errors.");
    }

    [SetsRequiredMembers]
    public Result(int statusCode, string statusMessage, T? value) : base(statusCode, statusMessage)
    {
        _Value = value;
    }

    [SetsRequiredMembers]
    public Result(int statusCode, string statusMessage, Error error) : base(statusCode, statusMessage, [error])
    {
        _Value = default;
    }

    public static implicit operator Result<T>(T value) => new(200, "Ok", value);
    public static implicit operator Result<T>(Error error) => new(error.ErrorCode, error.ErrorMessage, error);
}
