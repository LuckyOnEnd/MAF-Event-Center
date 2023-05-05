using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.SPA.Models.Events
{
    public class CreateEventDTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "Event name must be > 3 symbols")]
        public string eventName { get; set; }
        [Required]
        [FromNow]
        public DateTime StartEvent { get; set; }
        [Required]
        [FromNow]
        public DateTime EndEvent { get; set; }
        [Required]
        [Game]
        public Guid gameId { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "Description must be > 10 sybmols")]
        public string Description { get; set; }

        public class FromNowAttribute : ValidationAttribute
        {
            public FromNowAttribute() { }

            public string GetErrorMessage() => "Date must be past now";

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var date = (DateTime)value;

                if (DateTime.Compare(date, DateTime.Now) < 0) return new ValidationResult(GetErrorMessage());
                else return ValidationResult.Success;
            }
        }

        public class GameAttribute : ValidationAttribute
        {
            public GameAttribute() { }

            public string GetErrorMessage() => "Game must be choosen";

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var game = Guid.Parse(value.ToString());
                if (game == null || game == Guid.Empty) return new ValidationResult(GetErrorMessage());
                else return ValidationResult.Success;
            }
        }
    }
}
