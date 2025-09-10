using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using PlaygroundFunction.Interfaces;

namespace FunctionApp1;

public class BlobTrigger
{
    private readonly ILogger<BlobTrigger> _logger;
    private readonly IMessageQueueService _queueService;

    public BlobTrigger(ILogger<BlobTrigger> logger, IMessageQueueService queueService)
    {
        _logger = logger;
        _queueService = queueService;
    }

    [Function(nameof(BlobTrigger))]
    public async Task Run([BlobTrigger("container/{name}", Connection = "BlobStorage")] Stream stream, string name)
    {
        using var blobStreamReader = new StreamReader(stream);
        var content = await blobStreamReader.ReadToEndAsync();
        _logger.LogInformation("C# Blob trigger function Processed blob\n Name: {name}", name);


        await _queueService.EnqueueMessageAsync("blobupload", $"A blob has been uploaded with the name: {name}");
    }
}