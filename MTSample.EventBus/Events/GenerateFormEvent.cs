using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTSample.EventBus.Events
{
    public class GenerateFormEvent
    {
        public Guid RequestId { get; set; }
        public required string Content { get; set; }
    }
}
