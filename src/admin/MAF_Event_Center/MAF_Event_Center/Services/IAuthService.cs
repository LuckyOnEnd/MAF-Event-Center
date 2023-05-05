using MAF_Event_Center.SPA.Models.Auth;

namespace MAF_Event_Center.SPA.Services
{
    public interface IAuthService
    {
        Task<RegisterModelResult> Register(RegisterModel registerModel);
        Task<LoginModelResult> Login(LoginModel model);
        Task Logout();
    }
}
