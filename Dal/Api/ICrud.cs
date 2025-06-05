using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api;

public interface ICrud<T>
{
    List<T> GetAll();
    T? GetById(int id);
    void Delete(int id);
    Task Create(T entity);
    void Update(T entity);

}
