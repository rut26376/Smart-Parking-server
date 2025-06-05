using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models;

public class BlPaymentDetail
{
    public int Code { get; set; }

    public DateTime Date { get; set; }

    public double Sum { get; set; }

    public bool Paid { get; set; }
}
