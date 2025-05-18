using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models;

public class BlParking
{
    public int Code { get; set; }
    public string Row { get; set; } = null!;

    public short Col { get; set; }

    public string Level { get; set; } = null!;

}
