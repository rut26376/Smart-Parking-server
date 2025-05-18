using BL.Api;
using Dal.Api;
using Dal.Models;
using Dal.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using BL.Models;

namespace BL.Services;

public class BlRoutineService : IBLRoutine
{
    IDal dal;

    public BlRoutineService(IDal dal)
    {
        this.dal = dal;
    }

    public void Create(BlRoutine r)
    {
        dal.Routines.Create(new Routine()
        { ParkingCode = r.ParkingCode, LicensePlate = r.LicensePlate, Date = DateTime.Now.Date, EntryTime = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second) });

        dal.Parkings.Update(new CarParking() { Code = r.ParkingCode });
    }
    public bool checkIfDoesntExist(string licensePlate) => dal.Routines.GetRoutines().FindLast(r => r.LicensePlate == licensePlate) != null ? dal.Routines.GetRoutines().FindLast(r => r.LicensePlate == licensePlate).ExitTime != null : true;

    public int Find(string licensePlate) => dal.Routines.GetRoutines().FindLast(r => r.LicensePlate == licensePlate && r.ExitTime==null) != null ? dal.Routines.GetRoutines().FindLast(r => r.LicensePlate == licensePlate && r.ExitTime == null).ParkingCode : -1;

    public int? GetSum(string licensePlate)
    {

        Routine r = dal.Routines.GetRoutines().FindLast(d => d.LicensePlate == licensePlate);
        if (r == null || r.ExitTime != null) return -1;
        int numDays = 0;
        Console.WriteLine((DateTime.Now - r.Date).Value.TotalHours - 24);
        double numHours = (DateTime.Now - r.Date).Value.TotalHours - 24 + ( 24 - r.EntryTime.Value.Hours);
        Console.WriteLine(numDays);
        if (((numHours - (int)numHours)- r.EntryTime.Value.Minutes) * 100 > 60)
        {
            numHours++;
        }
        numDays = (int)numHours / 24;
        numHours = numHours % 24;

        //if (getHourPrice(numHours) == 50 && numDays == 0)
        //    r.TotalPayment = 50;
        //else
        //    r.TotalPayment = (int)(getDailyRate() * numDays + (int)numHours * getHourPrice(numHours));

        r.TotalPayment = getHourPrice(numHours);
        if(numDays > 0)
        {
            r.TotalPayment += (int)(getDailyRate() * numDays);
        }
        r.ExitTime = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

        dal.Routines.Update(r);

        return r.TotalPayment;

    }

    private int getHourPrice(double hours)
    {

        //קריאה מקובץ json.....
        StreamReader sr = new StreamReader("D:\\רותי לוין\\parkingProject\\parking project\\server\\Dal\\Json\\globalDetails.json");
        string data = sr.ReadToEnd();
        sr.Close();
        List<globalDetails> lst = JsonSerializer.Deserialize<List<globalDetails>>(data);
        return (int)hours != 0 ? lst[0].hourPrice*(int)hours : lst[0].minimumPrice;

    }
    private int getDailyRate()
    {

        //קריאה מקובץ json.....
        StreamReader sr = new StreamReader("F:\\תיקייה כללית חדש\\שנה ב תשפה\\קבוצה א\\תלמידות\\ה-פרויקט של סוף שנה מירי רבקי רותי\\Project C#\\Dal\\Json\\globalDetails.json");
        string data = sr.ReadToEnd();
        sr.Close();
        List<globalDetails> lst = JsonSerializer.Deserialize<List<globalDetails>>(data);

        return lst[0].dailyRate;

    }
}
