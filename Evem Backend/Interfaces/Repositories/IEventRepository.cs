using Evem_Backend.DTO;
using Evem_Backend.Models;

namespace Evem_Backend.Interfaces.Repositories
{
    public interface IEventRepository
    {
        public Task<List<Event>> GetUpcomingEvents();

        public Task<bool> UpdateEventStatus(int id, UpdateEventStatusDTO request);

        public Task<bool> DeleteEvent(int id);

        public Task<List<EventsNew>> GetPendingEvents();

        public Task<EventsNew> GetEventDetails(int id);

        public Task<List<EventsNew>> GetRegisteredUpcomingEvents();

        public Task<List<EventsNew>> GetRegisteredPastEvents();

        public Task<List<EventsNew>> GetEventDetailsByUserId(int id);
        
        public Task<bool> UpdateEvenetCompletion(int id, UpdateEventStatusDTO request);

    }

}

