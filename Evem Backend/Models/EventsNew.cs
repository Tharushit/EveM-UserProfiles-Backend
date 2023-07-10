using System;
using System.Collections.Generic;

namespace Evem_Backend.Models;

public partial class EventsNew
{
    public int Id { get; set; }

    public int? EventId { get; set; }

    public int? EmployeeId { get; set; }

    public string? EventName { get; set; }

    public string? EventDescription { get; set; }

    public string? EventType { get; set; }

    public string? EventImg { get; set; }

    public bool? IsSingle { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public bool? IsPhysical { get; set; }

    public string? Locations { get; set; }

    public string? EventAdditionalDoc { get; set; }

    public string? EventCommunityMember { get; set; }

    public bool? IsConfirmed { get; set; }

    public bool? IsPending { get; set; }

    public bool? IsRegistered { get; set; }

    public bool IsCompleted { get; set; }
}
