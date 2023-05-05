using MAF_Event_Center.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Domain.Entities
{
    public class Event
    {
        public Guid Id { get;  set; }
        public string ?Name { get; set; }
        public bool ? IsDeleted { get; set; } = false;
        public EventStatus Status { get; set; }
        public DateTime StartEvent { get; set; }
        public DateTime EndEvent { get; set;}
        public Guid GameId { get;  set; }
        public string ?HostLink { get; set; }
        public DateTime CreatedAt { get; set; }

        public string Description { get; set; }
        public string GameName { get; set; }
        public Guid CreatedUser { get; set; }

        public Event() { }
        public Event(Guid id,string name, DateTime startEvent, DateTime endEvent, Guid gameId, string hostLink, Guid createdUser, string gameName, string description)
        {
            Id = id;
            Name = name;
            StartEvent = startEvent;
            EndEvent = endEvent;
            GameId = gameId;
            HostLink = hostLink;
            CreatedAt = DateTime.Now;
            IsDeleted = false;
            CreatedUser = createdUser;
            GameName = gameName;
            Description = description;
        }
    }
}
