using MassTransit;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(x =>
{
    var mtConfig = builder.Configuration.GetSection("MassTransit");

    x.SetKebabCaseEndpointNameFormatter();

    x.SetRedisSagaRepositoryProvider(mtConfig.GetValue<string>("Redis:Configuration"));

    var entryAssembly = Assembly.GetEntryAssembly();

    x.AddConsumers(entryAssembly);
    x.AddSagaStateMachines(entryAssembly);
    x.AddSagas(entryAssembly);
    x.AddActivities(entryAssembly);

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(mtConfig.GetValue<string>("RabbitMQ:Host"), mtConfig.GetValue<string>("RabbitMQ:VirtualHost"), h => {
            h.Username(mtConfig.GetValue<string>("RabbitMQ:Username"));
            h.Password(mtConfig.GetValue<string>("RabbitMQ:Password"));
        });

        cfg.ConfigureEndpoints(context);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
