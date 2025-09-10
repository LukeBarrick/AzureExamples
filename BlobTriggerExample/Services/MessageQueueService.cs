using Azure.Storage.Queues;
using PlaygroundFunction.Common.Errors;
using PlaygroundFunction.Interfaces;
using SharedKernel.Abstractions;
using System.Text;

namespace PlaygroundFunction.Services;

public class MessageQueueService : IMessageQueueService
{
    private readonly QueueServiceClient _queueServiceClient;
    public MessageQueueService(QueueServiceClient queueServiceClient)
    {
        _queueServiceClient = queueServiceClient;
    }
    public async Task<Result> DequeueMessageAsync(string queueName, string messageId, string popReciept)
    {
        try
        {
            QueueClient queueClient = _queueServiceClient.GetQueueClient(queueName);
            var response = await queueClient.DeleteMessageAsync(messageId, popReciept);
        }
        catch (Exception ex)
        {
            return Result.Failure(MessagingErrors.DequeueMessageFailed(ex));
        }

        return Result.Success();
    }

    public async Task<Result> EnqueueMessageAsync(string queueName, string message)
    {
        try
        {
            QueueClient queueClient = _queueServiceClient.GetQueueClient(queueName);
            var plainTextBytes = Encoding.UTF8.GetBytes(message);
            var response = await queueClient.SendMessageAsync(Convert.ToBase64String(plainTextBytes));
        }
        catch (Exception ex)
        {
            return Result.Failure(MessagingErrors.EnqueueMessageFailed(ex));
        }

        return Result.Success();
    }
}
