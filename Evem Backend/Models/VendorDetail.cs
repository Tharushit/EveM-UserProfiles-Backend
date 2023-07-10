using System;
using System.Collections.Generic;

namespace Evem_Backend.Models;

public partial class VendorDetail
{
    public int VendorId { get; set; }

    public string? VendorName { get; set; }

    public string? ContactPerson { get; set; }

    public string? ContactNo { get; set; }

    public string? ContactEmail { get; set; }

    public string? ServiceOffered { get; set; }

    public string? AddInfo { get; set; }
}
