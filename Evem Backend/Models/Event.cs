using System;
using System.Collections.Generic;

namespace Evem_Backend.Models;

public partial class Event
{
    public int EventId { get; set; }

    public string EventName { get; set; } = null!;

    public string EventDesc { get; set; } = null!;

    public string EventType { get; set; } = null!;

    public string EventImg { get; set; } = null!;

    public bool IsSingle { get; set; }

    public DateTime? StartDateTime { get; set; }

    public DateTime? EndDateTime { get; set; }

    public bool IsPhysical { get; set; }

    public string Locations { get; set; } = null!;

    public string EventAdditionalDoc { get; set; } = null!;

    public string EventCommunityMember { get; set; } = null!;

    public int? IsConfirmed { get; set; }

    public int? Id { get; set; }

    public virtual User? IdNavigation { get; set; }

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
