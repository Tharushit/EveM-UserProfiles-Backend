using System;
using System.Collections.Generic;

namespace Evem_Backend.Models;

public partial class Notification
{
    public int NotificationId { get; set; }

    public string? NotificationContent { get; set; }

    public int? EventId { get; set; }

    public int? UserId { get; set; }

    public virtual Event? Event { get; set; }

    public virtual User? User { get; set; }
}
