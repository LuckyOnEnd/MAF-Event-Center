using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.SPA.Models.Auth
{
    public class LoginModelResult
    {
        public bool IsAuthSuccessful { get; set; }
        public string Token { get; set; }
        public string ErrorMessage { get; set; }

    }
}
