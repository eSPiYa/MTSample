using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTSample.EventBus.Models
{
    public class DocumentGenerateRequest
    {
        public required IEnumerable<Form> FormsList { get; set; }
    }
}
