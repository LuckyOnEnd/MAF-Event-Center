﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Domain.Entities
{
    public class Event
    {
        [Required]
        public Guid Id { get; private set; }
        [Required]
        public string ?Name { get; set; }
        [Required]
        public DateTime StartEvent { get; set; }
        [Required]
        public DateTime EndEvent { get; set;}
        [Required]
        public Game ?Game { get; set; }   
        public string ?HostLink { get; private set; }
        public DateTime CreatedAt { get; private set; }

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

        public Event() { }

    }
}
