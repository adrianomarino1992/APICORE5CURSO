using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCore5.Model;

namespace ApiCore5.Repository
{
    public interface IRepository<T> where T : IBase
    {        
        T Insert(T obj);
        T Delete(T obj);
        T Update(T obj);
        IEnumerable<T> GetAll();
    }
}
