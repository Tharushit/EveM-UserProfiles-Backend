using Evem_Backend.DTO;
using Evem_Backend.Interfaces.Repositories;
using Evem_Backend.Interfaces.Services;
using Evem_Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Evem_Backend.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepositoty;
        public EventService(IEventRepository eventRepository)
        {
            _eventRepositoty = eventRepository;
        }
        public async Task<List<Event>> GetUpcomingEvents()
        {
            var upcomingEventsList = await _eventRepositoty.GetUpcomingEvents();
            return upcomingEventsList;
            
        }

        public async Task<bool> UpdateEventStatus(int id, UpdateEventStatusDTO request)
        {
            var result =await _eventRepositoty.UpdateEventStatus(id, request);
            return result;  
        }

        public async Task<bool> UpdateEvenetCompletion(int id, UpdateEventStatusDTO request)
        {
            var result = await _eventRepositoty.UpdateEvenetCompletion(id, request);
            return result;
        }

        public async Task<bool> DeleteEvent(int id)
        {
            var result = await _eventRepositoty.DeleteEvent(id);
            return result;
        }

        public async Task<List<EventsNew>> GetPendingEvents()
        {
            var pendingEventList = await _eventRepositoty.GetPendingEvents();
            return pendingEventList;
        }

        public async Task<List<EventsNew>> GetRegisteredUpcomingEvents()
        {
            var registeredEventList = await _eventRepositoty.GetRegisteredUpcomingEvents();
            return registeredEventList;
        }

        public async Task<List<EventsNew>> GetRegisteredPastEvents()
        {
            var registeredEventList = await _eventRepositoty.GetRegisteredPastEvents();
            return registeredEventList;
        }

        public async Task<EventsNew> GetEventDetails(int id)
        {
            return await _eventRepositoty.GetEventDetails(id);
            
        }

        public async Task<List<EventsNew>> GetEventDetailsByUserId(int id)
        {
            return await _eventRepositoty.GetEventDetailsByUserId(id);

        }
    }
}



