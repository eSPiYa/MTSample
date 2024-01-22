using MTSample.EventBus.Events;
using MTSample.EventBus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTSample.EventBus.Extensions
{
    public static class DocumentGenerateRequestExtensions
    {
        public static GenerateDocumentEvent ToGenerateDocumentEvent(this DocumentGenerateRequest dgr)
        {
            return new GenerateDocumentEvent { RequestId = Guid.NewGuid(), FormsList = dgr.FormsList };
        }
    }
}
