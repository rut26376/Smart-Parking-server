using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api;

public interface IDalParking
{
    Task<List<CarParking>> GetCarParkings();

    void Update(CarParking p);
    void Update(int code);
}
