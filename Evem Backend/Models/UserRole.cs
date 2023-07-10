using System;
using System.Collections.Generic;

namespace Evem_Backend.Models;

public partial class UserRole
{
    public int? EventId { get; set; }

    public int? EmployeeId { get; set; }

    public string? Role { get; set; }
}
