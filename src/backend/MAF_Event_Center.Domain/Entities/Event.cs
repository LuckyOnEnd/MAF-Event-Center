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
        public Guid Id { get; private set; }
        public string ?Name { get; private set; }
        public DateTime StartEvent { get; private set; }
        public DateTime EndEvent { get; private set;}
        public Game Game { get; private set; }
        public string ?HostLink { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public Event() { }
        public Event(string name, DateTime startEvent, DateTime endEvent, Game game, string hostLink)
        {
            Id = Guid.NewGuid();
            Name = name;
            StartEvent = startEvent;
            EndEvent = endEvent;
            Game = game;
            HostLink = hostLink;
            CreatedAt = DateTime.Now;
        }
    }
}
