namespace SharedKernel.Abstractions;
public record Error(string code, string message)
{
    public static Error None => new Error("Error.None", "No error occurred.");
    public static Error NullValue => new Error("Error.NullValue", "Value was null.");
}