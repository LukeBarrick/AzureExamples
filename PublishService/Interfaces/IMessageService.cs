using SharedKernel.Abstractions;

namespace PublishService.Interfaces;

public interface IMessageService
{
    Task<Result> PublishMessage(object value, string queueName);
    Task<Result> PublishMessage(string raw, string queueName);
}
