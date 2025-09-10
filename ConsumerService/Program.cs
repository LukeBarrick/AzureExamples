using ConsumerService;
using Microsoft.Extensions.Azure;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<ConsumerWorker>();

var host = builder.Build();
host.Run();
