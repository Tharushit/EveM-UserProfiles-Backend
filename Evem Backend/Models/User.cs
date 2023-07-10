using System;
using System.Collections.Generic;

namespace Evem_Backend.Models;

public partial class User
{
    public int Id { get; set; }

    public int? EventId { get; set; }

    public string? Username { get; set; }

    public string? EventRole { get; set; }

    public string Email { get; set; } = null!;

    public int? EmployeeId { get; set; }

    public int? PhoneNumber { get; set; }

    public string? Designation { get; set; }

    public bool? IsPending { get; set; }

    public bool? IsRegistered { get; set; }

    public DateTime? RegisteredDate { get; set; }

    public DateTime? RequestedDate { get; set; }

    public virtual Event? Event { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}
