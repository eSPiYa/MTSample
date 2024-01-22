using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTSample.EventBus.Responses
{
    public class GenerateFormResponse
    {
        public Guid RequestId { get; set; }
        public required string Instance { get; set; }
        public required string Content { get; set; }
    }
}
