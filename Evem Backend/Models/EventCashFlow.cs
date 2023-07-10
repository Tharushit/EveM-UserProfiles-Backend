using System;
using System.Collections.Generic;

namespace Evem_Backend.Models;

public partial class EventCashFlow
{
    public int CexId { get; set; }

    public string? CexName { get; set; }

    public string? CexType { get; set; }

    public string? CexDate { get; set; }

    public int CexAmount { get; set; }
}
