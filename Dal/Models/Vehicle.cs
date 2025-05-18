using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Vehicle
{
    public string LicensePlate { get; set; } = null!;

    public string DriverCode { get; set; } = null!;

    public virtual Driver DriverCodeNavigation { get; set; } = null!;

    public virtual ICollection<Routine> Routines { get; set; } = new List<Routine>();
}
