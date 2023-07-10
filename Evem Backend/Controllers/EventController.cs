using Evem_Backend.DTO;
using Evem_Backend.Interfaces.Services;
using Evem_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.ComponentModel;

namespace Evem_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet("get-upcoming-events")]
        public async Task<IActionResult> GetUpcomingEvents()
        {
            try
            {
                var upcomingEventList = await _eventService.GetUpcomingEvents();
                if (upcomingEventList.Count == 0)
                {
                    return NotFound();
                }

                List<UpcominEventDTO> eventList = new List<UpcominEventDTO>();

                foreach (var upcomingEvent in upcomingEventList)
                {
                    eventList.Add(new UpcominEventDTO
                    {
                        eventName = upcomingEvent.EventName,
                        eventImage = upcomingEvent.EventImg,
                        eventDescription = upcomingEvent.EventDesc,
                        eventDate = upcomingEvent.StartDateTime
                    });
                }
                return Ok(eventList);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("get-pending-events")]

        public async Task<IActionResult> getpendingevents()
        {
            try
            {
                var pendingeventlist = await _eventService.GetPendingEvents();
                if (pendingeventlist.Count == 0)
                {
                    return NotFound();
                }
                List<PendingEventsDTO> pendingEventsList = new List<PendingEventsDTO>();



                foreach (var pendingevent in pendingeventlist)
                {
                    pendingEventsList.Add(new PendingEventsDTO
                    {
                        eventId= pendingevent.EventId,
                        eventName = pendingevent.EventName,
                        eventDescription = pendingevent.EventDescription,
                        eventImg = pendingevent.EventImg,
                        StartDate = pendingevent.StartDate
                    });
                }

                return Ok(pendingEventsList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("get-registered-upcoming-events")]

        public async Task<IActionResult> GetRegisteredUpcomingEvents()
        {
            try
            {
                var registeredEventList = await _eventService.GetRegisteredUpcomingEvents();
                if (registeredEventList.Count == 0)
                {
                    return NotFound();
                }
                List<PendingEventsDTO> registeredEventsList = new List<PendingEventsDTO>();

                foreach (var registeredevent in registeredEventList)
                {
                    registeredEventsList.Add(new PendingEventsDTO
                    {
                        eventId = registeredevent.EventId,
                        eventName = registeredevent.EventName,
                        eventDescription = registeredevent.EventDescription,
                        eventImg = registeredevent.EventImg,
                        StartDate = registeredevent.StartDate
                    });
                }

                return Ok(registeredEventsList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-registered-past-events")]

        public async Task<IActionResult> GetRegisteredPastEvents()
        {
            try
            {
                var registeredEventList = await _eventService.GetRegisteredPastEvents();
                if (registeredEventList.Count == 0)
                {
                    return NotFound();
                }
                List<PendingEventsDTO> registeredEventsList = new List<PendingEventsDTO>();

                foreach (var registeredevent in registeredEventList)
                {
                    registeredEventsList.Add(new PendingEventsDTO
                    {
                        eventId = registeredevent.EventId,
                        eventName = registeredevent.EventName,
                        eventDescription = registeredevent.EventDescription,
                        eventImg = registeredevent.EventImg,
                        StartDate = registeredevent.StartDate
                    });
                }

                return Ok(registeredEventsList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("update-event-status/{id}")]

        public async Task<IActionResult> UpdateEventStatus(int id, UpdateEventStatusDTO request)
        {
            var result = await _eventService.UpdateEventStatus(id, request);
            if (result)
            {
                return Ok("Updated Successfully.");

            }
            return BadRequest("Failed to Update");

        }

        [HttpPut("update-event-completion/{id}")]
        public async Task<IActionResult> UpdateEvenetCompletion(int id, UpdateEventStatusDTO request)
        {
            var result = await _eventService.UpdateEvenetCompletion(id, request);
            if (result)
            {
                return Ok("Updated Successfully.");

            }
            return BadRequest("Failed to Update");

        }


        [HttpDelete("delete-event/{id}")]

        public async Task<IActionResult> DeleteEvent(int id)
        {
            var result = await _eventService.DeleteEvent(id);
            if (result)
            {
                return Ok("Deleted Successfully.");

            }
            return BadRequest("Failed to Delete");

        }

        [HttpGet("get-event-by-id/{id}")]
        public async Task<IActionResult> GetEventDetails(int id)
        {
            try {
                var pendingEventList = await _eventService.GetEventDetails(id);

                if (pendingEventList == null)
                {
                    return NotFound();
                }
                PendingEventsDTO eventList = new PendingEventsDTO{
                    eventId = pendingEventList.EventId,
                    eventName = pendingEventList.EventName,
                    eventDescription = pendingEventList.EventDescription,
                    eventImg = pendingEventList.EventImg,
                    StartDate = pendingEventList.StartDate
                };
                
                return Ok(eventList);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpGet("get-events-by-user-id/{id}")]
        public async Task<IActionResult> GetEventDetailsByUserId(int id)
        {
            try
            {
                var eventsToGivenId = await _eventService.GetEventDetailsByUserId(id);

                if (eventsToGivenId.Count==0)
                {
                    return NotFound();
                }
                List<EventByIdDTO> eventList = new List<EventByIdDTO>();

                foreach(var eventToGivenId in eventsToGivenId)
                    eventList.Add(new EventByIdDTO
                    {
                    eventId = eventToGivenId.EventId,
                    eventName = eventToGivenId.EventName,
                    eventDescription = eventToGivenId.EventDescription,
                    eventImg = eventToGivenId.EventImg,
                    StartDate = eventToGivenId.StartDate,
                    eventCommunityMember = eventToGivenId.EventCommunityMember,
                    IsCompleted=eventToGivenId.IsCompleted
                });

                return Ok(eventList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }



    }

    
}
