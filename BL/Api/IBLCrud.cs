using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api;

public interface IBlCrud<T, S>
{
    List<T> GetAll();
    void Update(T item);
    void Delete(int id);

    T fromDalToBl(S item);
    S fromBlToDal(T item);
    List<T> listFromDalToBl(List<S> item);
    List<S> listFromBlToDal(List<T> item);
}
