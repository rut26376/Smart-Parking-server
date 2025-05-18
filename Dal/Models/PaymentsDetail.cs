using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class PaymentsDetail
{
    public int Code { get; set; }

    public int PaymentCode { get; set; }

    public DateTime Date { get; set; }

    public double Sum { get; set; }

    public bool Paid { get; set; }

    public virtual Payment PaymentCodeNavigation { get; set; } = null!;
}
