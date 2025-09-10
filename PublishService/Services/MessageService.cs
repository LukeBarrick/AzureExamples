using Azure.Messaging.ServiceBus;
using PublishService.Common.Abstractions.Errors;
using PublishService.Interfaces;
using SharedKernel.Abstractions;
using System.Text.Json;

namespace PublishService.Services;

public class MessageService : IMessageService
{
    private readonly ServiceBusClient _serviceBusClient;

    public MessageService(ServiceBusClient serviceBusClient)
    {
        _serviceBusClient = serviceBusClient;
    }

    public async Task<Result> PublishMessage(object value, string queueName)
    {
        try
        {
            var serviceBusSender = _serviceBusClient.CreateSender(queueName);
            var serialized = JsonSerializer.Serialize(value);
            await serviceBusSender.SendMessageAsync(new ServiceBusMessage(serialized));
            return Result.Success();
        } catch (Exception ex)
        {
            return Result.Failure(PublishingErrors.ExceptionOccured(ex));
        }
    }

    public async Task<Result> PublishMessage(string raw, string queueName)
    {
        try
        {
            var serviceBusSender = _serviceBusClient.CreateSender(queueName);
            await serviceBusSender.SendMessageAsync(new ServiceBusMessage(raw));
            return Result.Success();

        } catch (Exception ex)
        {
            return Result.Failure(PublishingErrors.ExceptionOccured(ex));
        }
    }
}
