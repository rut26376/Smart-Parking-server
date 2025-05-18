using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Payment
{
    public int Code { get; set; }

    public int RoutinelyCode { get; set; }

    public int CreditCardCode { get; set; }

    public int Sum { get; set; }

    public DateTime Date { get; set; }

    public virtual CreditCard CreditCardCodeNavigation { get; set; } = null!;

    public virtual ICollection<PaymentsDetail> PaymentsDetails { get; set; } = new List<PaymentsDetail>();
}
