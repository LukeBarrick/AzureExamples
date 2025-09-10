using Microsoft.Extensions.Azure;
using PublishService.Interfaces;
using PublishService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAzureClients(clientBuilder =>
{
    clientBuilder.AddServiceBusClient(builder.Configuration.GetConnectionString("ServiceBus"));
});

builder.Services.AddSingleton<IMessageService, MessageService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
