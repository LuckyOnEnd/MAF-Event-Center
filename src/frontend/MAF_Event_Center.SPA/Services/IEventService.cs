using MAF_Event_Center.SPA.Models;
using MAF_Event_Center.SPA.Models.Events;
using MAF_Event_Center.SPA.Models.UserEvents;
using System.Net.Http;
using System.Net;
using System.Runtime.CompilerServices;

namespace MAF_Event_Center.SPA.Services
{
    public interface IEventService
    {
        public Task<List<Event>> GetEvents();
        public Task<Event> GetEvent(Guid id);
        public Task<System.Net.HttpStatusCode> CreateEvent(CreateEventDTO model);
        public Task<HttpStatusCode> UpdateEvent(CreateEventDTO model);
        public Task<HttpStatusCode> DeleteEvent(Guid id);

        public Task<System.Net.HttpStatusCode> JoinUserToEvent(UserEvent userEvent);
        public Task<List<UserEventDTO>> GetUsersInEvent(Guid eventId);

        public Task<List<Event>> GetCreatedEventsByUser(Guid createdUser);

        public Task<List<Game>> GetGames();
        public Task<Game> GetGame(Guid id);
    }
}
