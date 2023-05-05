using MAF_Event_Center.SPA.Models;
using MAF_Event_Center.SPA.Models.Events;
using MAF_Event_Center.SPA.Models.UserEvents;
using System.Runtime.CompilerServices;

namespace MAF_Event_Center.SPA.Services
{
    public interface IEventService
    {
        public Task<List<Event>> GetEvents();
        public Task<Event> GetEvent(Guid id);
        public Task<System.Net.HttpStatusCode> CreateEvent(CreateEventDTO model);
        public Task<System.Net.HttpStatusCode> UpdateEvent(UpdateEventDTO model);
        public Task<System.Net.HttpStatusCode> DeleteEvent(Guid id);
        public Task<System.Net.HttpStatusCode> JoinUserToEvent(UserEvent userEvent);
        public Task<List<UserEventDTO>> GetUsersInEvent(Guid eventId);

        public Task<List<Event>> GetCreatedEventsByUser(Guid createdUser);

        public Task<List<Game>> GetGames();
        public Task<Game> GetGame(Guid id);
    }
}
