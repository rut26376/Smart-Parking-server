using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    public class DalRoutineService : IDalRoutine
    {
        dbcontext dbcontext;

        //c-tor
        public DalRoutineService(dbcontext data) => dbcontext = data;



        public void Create(Routine r)
        { 
            dbcontext.Routines.Add(r);
            dbcontext.SaveChanges();
        }
       

        public void Delete(Routine r)
        {

            dbcontext.Routines.Remove(r);
            dbcontext.SaveChanges();
        }
       
     

        public List<Routine> GetRoutines() => dbcontext.Routines.ToList();

        public void Update(Routine r)
        {
            try
            {
                var current = dbcontext.Routines.Find(r.Code);
                current.ExitTime = r.ExitTime;
                current.TotalPayment = r.TotalPayment;
                dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException(ex.ToString());
            };
        }
    }
}
