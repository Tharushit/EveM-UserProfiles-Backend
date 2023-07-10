using Evem_Backend.DTO;
using Evem_Backend.Interfaces.Repositories;
using Evem_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Evem_Backend.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly EvemContext _context;

        public EventRepository(EvemContext context)
        {
            _context = context;
        }
        public async Task<List<Event>> GetUpcomingEvents()
        {
            return _context.Events.ToList();

        }

        public async Task<bool> UpdateEventStatus(int id, UpdateEventStatusDTO request)
        {
            var nullEvent = new EventsNew();
            nullEvent.Id = 0;
          
            var eventTableRow = _context.EventsNews.Where(eventTableRow => eventTableRow.EventId == id).FirstOrDefault() == null ? nullEvent : _context.EventsNews.Where(eventTableRow => eventTableRow.EventId == id).FirstOrDefault();

            if (eventTableRow.EventId == 0)
            {
                return false;
            }
            try
            {
                eventTableRow.IsPending = request.status;
                _context.Update(eventTableRow);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;   
            }
           
         }

        public async Task<bool> UpdateEvenetCompletion(int id, UpdateEventStatusDTO request)
        {
            var nullEvent = new EventsNew();
            nullEvent.Id = 0;

            var eventTableRow = _context.EventsNews.Where(eventTableRow => eventTableRow.EventId == id).FirstOrDefault() == null ? nullEvent : _context.EventsNews.Where(eventTableRow => eventTableRow.EventId == id).FirstOrDefault();

            if (eventTableRow.EventId == 0)
            {
                return false;
            }
            try
            {
                eventTableRow.IsCompleted = request.status;
                _context.Update(eventTableRow);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<bool> DeleteEvent(int id)
        {
            var nullEvent = new EventsNew();
            nullEvent.Id = 0;

            var eventTableRow = _context.EventsNews.Where(eventTableRow => eventTableRow.EventId == id).FirstOrDefault() == null ? nullEvent : _context.EventsNews.Where(eventTableRow => eventTableRow.EventId == id).FirstOrDefault();

            if (eventTableRow.EventId == 0)
            {
                return false;
            }
            try
            {
               
                _context.EventsNews.Remove(eventTableRow);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<List<EventsNew>> GetPendingEvents()
        {
           return _context.EventsNews.Where(e => e.IsPending==true).ToList();
           
        }

        public async Task<List<EventsNew>> GetRegisteredUpcomingEvents()
        {
            DateTime today = DateTime.Today;
            return await _context.EventsNews
                .Where(e => e.IsPending == false&&e.StartDate>=today)
                .OrderBy(e=>e.StartDate)
                .ToListAsync();
        }

        public async Task<List<EventsNew>> GetRegisteredPastEvents()
        {
            DateTime today = DateTime.Today;
            return await _context.EventsNews
                .Where(e => e.EndDate < today  && e.IsCompleted == true)
                .OrderByDescending(e => e.EndDate)
                .ToListAsync();
        }

        public async Task<EventsNew> GetEventDetails(int id)
        {
            return await _context.EventsNews.FirstOrDefaultAsync(tableRow => tableRow.EventId == id);
        }

        public async Task<List<EventsNew>> GetEventDetailsByUserId(int id)
        {
            return await _context.EventsNews.Where(tableRow => tableRow.EmployeeId == id).ToListAsync();
        }

    }

}
