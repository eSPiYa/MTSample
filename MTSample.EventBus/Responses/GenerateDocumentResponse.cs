using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTSample.EventBus.Responses
{
    public class GenerateDocumentResponse
    {
        public Guid RequestId { get; set; }
        public required IEnumerable<GenerateFormResponse> FormsResponses { get; set; }
    }
}
