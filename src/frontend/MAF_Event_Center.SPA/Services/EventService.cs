using MAF_Event_Center.SPA.Models.Events;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace MAF_Event_Center.SPA.Services
{
    public class EventService : IEventService
    {
        private readonly HttpClient _httpClient;

        public EventService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Event>> GetEvents()
        { 
            var result = await _httpClient.GetFromJsonAsync<Event[]>("https://localhost:7034/Event/GetAll");

            return result.ToList();
        }
    }
}
