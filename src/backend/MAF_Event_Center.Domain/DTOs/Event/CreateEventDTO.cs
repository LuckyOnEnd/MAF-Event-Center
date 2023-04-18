using MAF_Event_Center.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Domain.DTOs.Event
{
    public class CreateEventDTO
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public DateTime StartEvent { get; set; }
        [Required]
        public DateTime EndEvent { get; set; }
        [Required]
        public Game? Game { get; set; }
        public string? HostLink { get; private set; }
    }
}
