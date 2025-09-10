using Azure.Storage.Queues.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace PlaygroundFunction;

public class BlobUploadSubscriber
{
    private readonly ILogger<BlobUploadSubscriber> _logger;

    public BlobUploadSubscriber(ILogger<BlobUploadSubscriber> logger)
    {
        _logger = logger;
    }

    [Function(nameof(BlobUploadSubscriber))]
    public void Run([QueueTrigger("blobupload", Connection = "AzureWebJobsStorage")] QueueMessage message)
    {
        throw new InvalidOperationException();
        _logger.LogInformation("C# Queue trigger function processed: {messageText}", message.MessageText);
    }
}