using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class CarParking
{
    public int Code { get; set; }

    public string Row { get; set; } = null!;

    public short Col { get; set; }

    public string Level { get; set; } = null!;

    public bool Used { get; set; }

    public virtual ICollection<Routine> Routines { get; set; } = new List<Routine>();
}
