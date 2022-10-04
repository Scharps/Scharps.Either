namespace Scharps.Either;

public struct Result
{
    public static Result<TError> Ok<TError>()
        where TError : IError
    {
        return new Result<TError>();
    }

    public static Result<TError> Error<TError>(TError error)
        where TError : IError
    {
        return new Result<TError>(error);
    }

    public static Result<TError, TValue> Ok<TError, TValue>(TValue value)
        where TError : IError
    {
        return new Result<TError, TValue>(value);
    }

    public static Result<TError, TValue> Error<TError, TValue>(TError error)
    where TError : IError
    {
        return new Result<TError, TValue>(error);
    }
}

public struct Result<TError>
    where TError : IError
{
    public Result() { }
    public Result(TError error)
    {
        Error = error;
    }

    public TError? Error { get; } = default;

    public bool IsOk() => Error is null;

    public static implicit operator TError(Result<TError> result)
    {
        return result.Error!;
    }
}

public struct Result<TError, TValue>
    where TError : IError
{
    public Result(TValue value)
    {
        Value = value;
    }

    public Result(TError error)
    {
        Error = error;
    }

    public bool IsOk() => Error is null;

    public TValue? Value { get; } = default;
    public TError? Error { get; } = default;
    public static implicit operator TValue(Result<TError, TValue> result)
    {
        return result.Value!;
    }

    public static implicit operator TError(Result<TError, TValue> result)
    {
        return result.Error!;
    }
}