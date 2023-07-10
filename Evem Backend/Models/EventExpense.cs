using System;
using System.Collections.Generic;

namespace Evem_Backend.Models;

public partial class EventExpense
{
    public int TransacId { get; set; }

    public string? TransacName { get; set; }

    public string? TransacType { get; set; }

    public string? TransacDate { get; set; }

    public int TransacAmount { get; set; }
}
