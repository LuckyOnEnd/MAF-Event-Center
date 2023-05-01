using MAF_Event_Center.SPA.Models;
using MAF_Event_Center.SPA.Models.User;

namespace MAF_Event_Center.SPA.Services
{
    public interface IUserService
    {
        public Task<AppUserDTO> GetUserByName(string username);

        public Task<UserRoleResult> GetUserRole();
    }
}
