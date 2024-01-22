using MassTransit;
using MTSample.EventBus.Events;
using MTSample.EventBus.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTSample.BackgroundWorker.Consumers
{
    public class GenerateFormEventConsumer : IConsumer<GenerateFormEvent>
    {
        readonly ILogger<GenerateFormEvent> _logger;
        public GenerateFormEventConsumer(ILogger<GenerateFormEvent> logger)
        {
            _logger = logger;
        }
        public Task Consume(ConsumeContext<GenerateFormEvent> context)
        {
            context.RespondAsync(new GenerateFormResponse
            {
                RequestId = context.Message.RequestId,
                Instance = System.Environment.MachineName,
                Content = context.Message.Content
            });

            return Task.CompletedTask;
        }
    }
}
