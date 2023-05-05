using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.SPA.Models.User
{
    public class AppUser
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Rank { get; set; }

        public string CanCreate { get; set; }
    }
}
