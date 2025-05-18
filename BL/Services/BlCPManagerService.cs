using BL.Api;
using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services;

public class BlCPManagerService : IBLCPManager
{
    IDal dal;

    //c-tor
    public BlCPManagerService(IDal dal) => this.dal = dal;

    public void Create(string p)
    {
        dal.Manager.Create(new Manager() { ManagerPassword = p });
    }

    public List<string> GetAll() 
    { 
        List<string> list = new List<string>();
        dal.Manager.GetManagersPasswords().ForEach(p =>list.Add(p.ManagerPassword));
        return list;
    }


}
