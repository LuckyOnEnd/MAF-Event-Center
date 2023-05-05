using MAF_Event_Center.SPA.Models;
using MAF_Event_Center.SPA.Models.Events;
using MAF_Event_Center.SPA.Models.UserEvents;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;

namespace MAF_Event_Center.SPA.Services
{
    public class EventService : IEventService
    {
        private readonly HttpClient _httpClient;

        public EventService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<System.Net.HttpStatusCode> CreateEvent(CreateEventDTO model)
        {
            var resut =  await _httpClient.PostAsJsonAsync($"/Event/CreateEvent", model);

            return resut.StatusCode;
        }

        public async Task<Event> GetEvent(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<Event>($"/Event/GetEventById?id={id}");

            return result;
        }

        public async Task<List<Event>> GetEvents()
        { 
            var result = await _httpClient.GetFromJsonAsync<Event[]>("/Event/GetAll");

            return result.ToList();
        }

        public async Task<Game> GetGame(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<Game>($"/Game/GetById?Id={id}");

            return result;
        }

        public async Task<List<Game>> GetGames()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Game>>($"/Game/GetAll");

            return result;
        }

        public async Task<List<UserEventDTO>> GetUsersInEvent(Guid eventId)
        {
            var result = await _httpClient.GetFromJsonAsync<List<UserEventDTO>>($"/Event/GetAllUserInEvent?Id={eventId}");

            return result;
        }

        public async Task<System.Net.HttpStatusCode> JoinUserToEvent(UserEvent userEvent)
        {
            var result =  await _httpClient.PostAsJsonAsync("/Event/JoinToEvent", userEvent);

            return result.StatusCode;
        }

        public async Task<List<Event>> GetCreatedEventsByUser(Guid createdUser)
        {
            var result = await _httpClient.GetFromJsonAsync<Event[]>("/Event/GetAll");

            return result.Where(x => x.CreatedUser == createdUser).ToList();
        }

        public async Task<HttpStatusCode> UpdateEvent(CreateEventDTO model)
        {
            var result = await _httpClient.PutAsJsonAsync("/Event/EditEvent", model);
            return result.StatusCode;
        }

        public async Task<HttpStatusCode> DeleteEvent(Guid id)
        {
            var result = await _httpClient.DeleteAsync($"/Event/DeleteEvent?id={id}");

            return result.StatusCode;
        }
    }
}
