using Azure.Messaging.ServiceBus;

namespace ConsumerService
{
    public class ConsumerWorker : BackgroundService
    {
        private readonly ILogger<ConsumerWorker> _logger;

        public ConsumerWorker(ILogger<ConsumerWorker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync([ServiceBusTrigger(
            queueName: "%ServiceBus:QueueName%",
            Connection = "ServiceBus:Connection",
            AutoCompleteMessages = false,
            IsSessionsEnabled = false)] // set true if using sessions
        ServiceBusReceivedMessage message,
        ServiceBusMessageActions messageActions, CancellationToken ctstoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
