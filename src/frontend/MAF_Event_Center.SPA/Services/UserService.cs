using MAF_Event_Center.SPA.Models;
using Microsoft.AspNetCore.Http;
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
        public async Task<AppUserDTO> GetUserByName(string username)
        {
            var result = await _http.GetFromJsonAsync<AppUserDTO>($"/api/User/GetByName?Username={username}");
            return result;
        }
    }
}
