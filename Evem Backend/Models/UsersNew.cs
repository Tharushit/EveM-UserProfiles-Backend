using System;
using System.Collections.Generic;

namespace Evem_Backend.Models;

public partial class UsersNew
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public int? EmployeeId { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Designation { get; set; }
}
