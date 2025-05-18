using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api;

public interface IBLRoutine
{
    int? GetSum(string licensePlate);

    void Create(BlRoutine r);

    int Find(string licensePlate);

    bool checkIfDoesntExist(string licensePlate);

}
