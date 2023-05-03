using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Domain.DTOs.AppUser
{
    public class AppUserManager
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Rank { get; set; }
        public string CanCreate { get; set; }
    }
}
