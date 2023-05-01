using System.ComponentModel.DataAnnotations;

namespace MAF_Event_Center.SPA.Models.Events
{
    public class Event
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool? IsDeleted { get; set; } = false;
        public EventStatus Status { get; set; }
        public DateTime StartEvent { get; set; }
        public DateTime EndEvent { get; set; }
        public Guid GameId { get; set; }
        public string? HostLink { get; set; }
        public DateTime CreatedAt { get; set; }
        public string GameName { get; set; }
        public Guid CreatedUser { get; set; }
    }
}

