using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models;

public class BlPayment
{

    public int CreditCardCode { get; set; }

    public int Sum { get; set; }

    public DateTime Date { get; set; }

    public List<BlPaymentDetail> PaymentsDetails { get; set; } = new List<BlPaymentDetail>();

}
