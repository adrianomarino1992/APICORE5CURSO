using ApiCore5.Model;
using ApiCore5.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using ApiCore5.Repository;

namespace ApiCore5.Business.Implementations
{
    public class PersonBusiness : IPersonBusiness
    {
        private readonly IPersonRepository _repository;

        public PersonBusiness(IPersonRepository repository)
        {
            _repository = repository;
        }

        public Person Create(Person person)
        {
            try
            {
                _repository.Create(person);
               
                return person;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
           
        }

        public IEnumerable<Person> Get()
        {

            return _repository.Get();
        }        

        public Person Get(int id)
        {
            return _repository.Get(id);
        }

        public Person Update(Person person)
        {
           return _repository.Update(person);
        }

        

       

        

        
    }
}
