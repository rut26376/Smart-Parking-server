using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api;

public interface IDalRoutine
{
    List<Routine> GetRoutines();

    void Create(Routine r);

    void Update(Routine r);

    void Delete(Routine r);
}
