using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTSample.EventBus.Events;
using MTSample.EventBus.Extensions;
using MTSample.EventBus.Models;
using MTSample.EventBus.Responses;

namespace MTSample.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentGenerateController : ControllerBase
    {
        private readonly IBus _bus;
        private readonly IRequestClient<GenerateDocumentEvent> _generateDocumentClient;

        public DocumentGenerateController(IBus bus, IRequestClient<GenerateDocumentEvent> generateDocumentClient)
        {
            _bus = bus;
            _generateDocumentClient = generateDocumentClient;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(DocumentGenerateRequest request, CancellationToken ct)
        {
            var result = await _generateDocumentClient.GetResponse<GenerateDocumentResponse>(request.ToGenerateDocumentEvent(), ct);

            return Ok(result.Message);
        }
    }
}
