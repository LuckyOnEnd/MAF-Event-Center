using MAF_Event_Center.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Application.Services.AccountService
{
    public interface IAuthService
    {
        Task<RegisterModelResult> SignUp(RegisterModel model, string role);

        Task<LoginModelResult> SignIn(LoginModel model);
    }
}
