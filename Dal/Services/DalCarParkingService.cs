using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services;

internal class DalCarParkingService : IDalParking
{
    dbcontext dbcontext;

    //c-tor
    public DalCarParkingService(dbcontext data) => dbcontext = data;

    public async Task<List<CarParking>> GetCarParkings()=> await dbcontext.CarParkings.ToListAsync();

    public void Update(CarParking parking)
    {
        dbcontext.CarParkings.Find(parking.Code).Used = !parking.Used;
        dbcontext.SaveChanges();
    }
    public void Update(int parkingCode)
    {
        dbcontext.CarParkings.Find(parkingCode).Used = false;
        
        dbcontext.SaveChanges();
    }


}
