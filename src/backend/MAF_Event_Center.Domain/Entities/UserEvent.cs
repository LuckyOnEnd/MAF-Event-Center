using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Domain.Entities
{
    public class UserEvent
    {
        public Guid Id { get; set; }
        public Guid EventId { get; set; }

        public UserEvent() { }

        public UserEvent(Guid id, Guid eventId)
        {
            Id = id;
            EventId = eventId;
        }
    }
}
