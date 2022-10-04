# Scharps.Either

Either is a light result library to distinguish between errors and successful results without the use of exceptions.

## Usage

```csharp
Result<Error> failedResult = CouldFail();
Result<Error, string> successfulResult = SuccessfulResult();

if (successfulResult.Value is string s)
{
    System.Console.WriteLine(s);
}
else if (successfulResult.Error is Error e)
{
    System.Console.WriteLine(e.Message);
}
```
