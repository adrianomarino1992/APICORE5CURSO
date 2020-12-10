using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCore5.Model;

namespace ApiCore5.Business
{
    public interface IPersonBusiness
    { 
    
        Person Create(Person person);
        Person Update(Person person);
        void Delete(int id);
        IEnumerable<Person> Get();
        Person Get(int id);

    }



}
