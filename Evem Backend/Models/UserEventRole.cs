using System;
using System.Collections.Generic;

namespace Evem_Backend.Models;

public partial class UserEventRole
{
    public int Id { get; set; }

    public int? EventId { get; set; }

    public int? EmployeeId { get; set; }

    public string? EmployeeRole { get; set; }
}
