using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustGiving.Api.Sdk2.Model.Event.Request
{
    public class EventRegistration
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CompletionDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? StartDate { get; set; }
        public string EventType { get; set; }
    }
}
