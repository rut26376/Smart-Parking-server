using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api;

public interface IBLParking
{
    BlParking Get(string level);

    void Update(BlParking p);

    List<BlCarParkings> GetAll(string level);
}
