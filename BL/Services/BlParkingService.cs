using BL.Api;
using BL.Models;
using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services;

public class BlParkingService : IBLParking
{
    IDal dal;


    public BlParkingService(IDal dal) => this.dal = dal;


    public BlParking? Get(string level)
    {
        var p = dal.Parkings.GetCarParkings().Find(p => !p.Used && p.Level == level);

        return p != null ? new BlParking() { Code = p.Code, Col = p.Col, Level = p.Level, Row = p.Row } : null;
    }

    public void Update(BlParking park)=> dal.Parkings.Update(dal.Parkings.GetCarParkings().Find(p => p.Code == park.Code));

 
    public List<BlCarParkings> GetAll(string level)
    {

        var pList = dal.Parkings.GetCarParkings().FindAll(p => p.Level == level);
        List<BlCarParkings> list = new();
        pList.ForEach(p => list.Add(new BlCarParkings()
        {
            Code = p.Code,
            Row = p.Row,
            Col = p.Col,
            Level = p.Level,
            Used = p.Used
        }));
        return list;

    }


}
