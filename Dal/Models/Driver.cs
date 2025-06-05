using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Driver
{
    public string Code { get; set; } = null!;

    public string? Name { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public virtual ICollection<CreditCard> CreditCards { get; set; } = new List<CreditCard>();

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
