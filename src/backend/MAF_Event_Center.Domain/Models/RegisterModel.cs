using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Domain.Models
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long", MinimumLength = 3)]
        [Display(Name = "Username")]
        public string? UserName { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "The {0} must be at leat {2} and at max {1} characters long", MinimumLength = 3)]
        [Display(Name = "Rank")]
        public string? Rank { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage ="The password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }
    }
}
