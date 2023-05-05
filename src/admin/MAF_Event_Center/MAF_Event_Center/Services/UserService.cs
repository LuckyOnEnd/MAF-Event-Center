using MAF_Event_Center.SPA.Models;
using MAF_Event_Center.SPA.Models.User;
using System.Net;
using System.Net.Http.Json;

namespace MAF_Event_Center.SPA.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _http;
        public UserService(HttpClient http)
        {
            _http = http;
        }
        public async Task<AppUser> GetUserByName(string username)
        {
            var result = await _http.GetFromJsonAsync<AppUser>($"/api/User/GetByName?Username={username}");
            return result;
        }

        public Task<UserRoleResult> GetUserRole()
        {
            var result = _http.GetFromJsonAsync<UserRoleResult>("/api/User/GetUserRole");

            return result;
        }

        public async Task<List<AppUser>> GetUsers()
        {
            var result = await _http.GetFromJsonAsync<List<AppUser>>("/api/User/GetAll");

            return result;
        }

        public Task<AppUserDTO> GetUserById(Guid id)
        {
            var result = _http.GetFromJsonAsync<AppUserDTO>($"/api/User/GetById?Id={id}");

            return result;
        }

        public async Task<HttpStatusCode> UpdateUser(CreateUserManager model)
        {
            var result = await _http.PutAsJsonAsync($"/api/User/Update", model);

            return result.StatusCode;
        }

        public Task<CreateUserManager> CreateUserManager(CreateUserManager model)
        {
            throw new NotImplementedException();
        }

        public async Task<AppUser> GetCurrentUser()
        {
            var result = await _http.GetFromJsonAsync<AppUser>("/api/User/CurrentUser");

            return result;
        }
    }
}
