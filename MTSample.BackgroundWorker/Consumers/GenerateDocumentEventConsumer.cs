using MassTransit;
using MTSample.EventBus.Events;
using MTSample.EventBus.Models;
using MTSample.EventBus.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MTSample.BackgroundWorker.Consumers
{
    public class GenerateDocumentEventConsumer : IConsumer<GenerateDocumentEvent>
    {
        private readonly ILogger<GenerateDocumentEvent> _logger;
        private readonly IRequestClient<GenerateFormEvent> _generateFormClient;

        public GenerateDocumentEventConsumer(ILogger<GenerateDocumentEvent> logger, IRequestClient<GenerateFormEvent> generateFormClient)
        {
            _logger = logger;
            _generateFormClient = generateFormClient;
        }

        public async Task Consume(ConsumeContext<GenerateDocumentEvent> context)
        {
            var processForms = context.Message.FormsList.Select(async form => await ProcessForm(form, context.CancellationToken));

            var formsResults = await Task.WhenAll(processForms);

            await context.RespondAsync(new GenerateDocumentResponse
            {
                RequestId = context.Message.RequestId,
                FormsResponses = formsResults
            });
        }

        private async Task<GenerateFormResponse> ProcessForm(Form form, CancellationToken cancellationToken)
        {
            var message = new GenerateFormEvent {
                RequestId = Guid.NewGuid(),
                Content = form.Content
            };

            var response = await _generateFormClient.GetResponse<GenerateFormResponse>(message, cancellationToken);

            return response.Message;
        }
    }
}
