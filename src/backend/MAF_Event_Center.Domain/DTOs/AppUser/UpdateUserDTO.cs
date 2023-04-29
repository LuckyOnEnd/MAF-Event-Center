using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Domain.DTOs.AppUser
{
    public class UpdateUserDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Rank { get; set; }
        public string Role { get; set; }
        public string CanCreate { get; set; }
    }
}
