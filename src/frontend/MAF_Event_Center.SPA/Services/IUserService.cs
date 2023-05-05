using MAF_Event_Center.SPA.Models;
using MAF_Event_Center.SPA.Models.User;
using System.Net;

namespace MAF_Event_Center.SPA.Services
{
    public interface IUserService
    {
        public Task<List<AppUser>> GetUsers();
        public Task<AppUserDTO> GetUserByName(string username);
        public Task<AppUserDTO> GetUserById(Guid id);
        public Task<CreateUserManager> CreateUserManager(CreateUserManager model);
        public Task<HttpStatusCode> UpdateUser(CreateUserManager model);

        public Task<UserRoleResult> GetUserRole();

        public Task<AppUser> GetCurrentUser();
    }
}
