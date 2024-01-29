using MassTransit;
using MTSample.BackgroundWorker;
using System.Reflection;

var builder = Host.CreateApplicationBuilder(args);

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

builder.Logging.AddConsole();

var host = builder.Build();
host.Run();
