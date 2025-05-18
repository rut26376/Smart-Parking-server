using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class BlCreditCards
    {
        public int Code { get; set; }
        public string CreditCardNum { get; set; } = null!;
        public string ValidityCard { get; set; }
        public string Id { get; set; } = null!;
        public string Cvv { get; set; } = null!;
        public string DriverCode { get; set; } = null!;


    }
}
