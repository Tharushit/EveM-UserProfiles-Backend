﻿namespace Evem_Backend.DTO
{
    public class PendingEventsDTO
    {
        public int? eventId { get; set; }
        public string? eventName { get; set; }
        public string? eventDescription { get; set; }
        public string? eventImg { get; set; }
        public DateTime? StartDate { get; set; }

    }
}
