using MTSample.EventBus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTSample.EventBus.Events
{
    public class GenerateDocumentEvent
    {
        public Guid RequestId { get; set; }
        public required IEnumerable<Form> FormsList { get; set; }
    }
}
