using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class CreditCard
{
    public int Code { get; set; }

    public string CreditCardNum { get; set; } = null!;

    public string ValidityCard { get; set; } = null!;

    public string Cvv { get; set; } = null!;

    public string Id { get; set; } = null!;

    public string DriverCode { get; set; } = null!;

    public virtual Driver DriverCodeNavigation { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
