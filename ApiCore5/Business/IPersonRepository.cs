using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCore5.Repository;
using ApiCore5.Model;
using System.Linq.Expressions;

namespace ApiCore5.Business
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person GetPerson(Expression<Func<Person, bool>> expression);
       
    }
}
