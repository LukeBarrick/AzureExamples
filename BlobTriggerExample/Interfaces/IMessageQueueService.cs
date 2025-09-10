using SharedKernel.Abstractions;

namespace PlaygroundFunction.Interfaces;

public interface IMessageQueueService
{
    Task<Result> EnqueueMessageAsync(string queueName, string message);
    Task<Result> DequeueMessageAsync(string queueName, string messageId, string popReciept);
}
