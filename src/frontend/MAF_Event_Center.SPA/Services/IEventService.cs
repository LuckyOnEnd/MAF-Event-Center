using MAF_Event_Center.SPA.Models.Events;
using System.Runtime.CompilerServices;

namespace MAF_Event_Center.SPA.Services
{
    public interface IEventService
    {
        public Task<List<Event>> GetEvents();
        public Task<Event> GetEvent(Guid id);

        public Task<System.Net.HttpStatusCode> JoinUserToEvent(UserEvent userEvent);
    }
}
