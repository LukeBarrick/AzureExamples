using SharedKernel.Abstractions;

namespace PublishService.Common.Abstractions.Errors;

public static class PublishingErrors
{
    public static Error ExceptionOccured(Exception ex) => new($"{nameof(PublishingErrors)}.{nameof(ExceptionOccured)}", $"An error occured whilst publishing a message. Failed with error message: {ex.Message}");
}
