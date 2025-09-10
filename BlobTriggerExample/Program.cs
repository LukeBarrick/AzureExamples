using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlaygroundFunction.Interfaces;
using PlaygroundFunction.Services;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

builder.Services
    .AddApplicationInsightsTelemetryWorkerService()
    .ConfigureFunctionsApplicationInsights();

builder.Services.AddAzureClients(builder =>
{
    builder.AddQueueServiceClient(Environment.GetEnvironmentVariable("AzureWebJobsStorage"));
    builder.AddBlobServiceClient(Environment.GetEnvironmentVariable("BlobStorage"));
});

builder.Services.AddScoped<IMessageQueueService, MessageQueueService>();

builder.Build().Run();