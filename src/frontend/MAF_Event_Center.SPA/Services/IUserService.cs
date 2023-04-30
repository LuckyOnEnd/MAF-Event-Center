using MAF_Event_Center.SPA.Models;

namespace MAF_Event_Center.SPA.Services
{
    public interface IUserService
    {
        public Task<AppUserDTO> GetUserByName(string username);
    }
}
