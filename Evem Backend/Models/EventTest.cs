using System;
using System.Collections.Generic;

namespace EvemWebBEc.Models
{
    public class EventTest
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string EventDesc { get; set; }
        public string EventType { get; set; }
        public string EventImg { get; set; }
        public bool IsSingle { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public bool IsPhysical { get; set; }
        public string Locations { get; set; }
        public string EventAdditionalDoc { get; set; }
        public string EventCommunityMember { get; set; }
        public bool isConfirm { get; set; } = false;
    }

}