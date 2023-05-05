using MAF_Event_Center.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Domain.DTOs.Events
{
    public class UpdateEventDTO
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string? Name { get; set; }

        [Required]
        public DateTime StartEvent { get; set; }
        [Required]
        public DateTime EndEvent { get; set; }
        [Required]
        public Guid gameId { get; set; }
    }
}
