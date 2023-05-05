using MAF_Event_Center.Models.Game;
using MAF_Event_Center.SPA.Models;
using System.Net.Http.Json;

namespace MAF_Event_Center.SPA.Services
{
    public class GameService : IGameService
    {
        private readonly HttpClient _http;
        
        public GameService(HttpClient http)
        {
            _http = http;
        }
        public async Task CreateGame(CreateGame game)
        {
            await _http.PostAsJsonAsync("/Game/Create", game);
        }

        public async Task Delete(Guid Id)
        {
            await _http.DeleteAsync($"/Game/Delete?id={Id}");
        }

        public Task<List<Game>> GetAll()
        {
            var result = _http.GetFromJsonAsync<List<Game>>("/Game/GetAll");

            return result;
        }
    }
}
