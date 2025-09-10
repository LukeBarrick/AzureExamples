using SharedKernel.Abstractions;

namespace PlaygroundFunction.Common.Errors;

public static class MessagingErrors
{
    public static Error EnqueueMessageFailed(Exception ex) => new("MessagingErrors.EnqueueMessageFailed", $"Failed to enqueue message with exception {ex.Message}");
    public static Error DequeueMessageFailed(Exception ex) => new("MessagingErrors.DequeueMessageFailed", $"Failed to dequeue message with exception {ex.Message}");
}
