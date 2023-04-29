using MAF_Event_Center.SPA.Models.Events;

namespace MAF_Event_Center.SPA.Services
{
    public interface IEventService
    {
        public Task<List<Event>> GetEvents();
    }
}
