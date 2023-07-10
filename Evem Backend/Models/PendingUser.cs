using System;
using System.Collections.Generic;

namespace Evem_Backend.Models;

public partial class PendingUser
{
    public int? EventId { get; set; }

    public string Email { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Role { get; set; } = null!;

    public DateTime? RequestDate { get; set; }

    public virtual Event? Event { get; set; }
}
