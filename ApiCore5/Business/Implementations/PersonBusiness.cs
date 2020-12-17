using ApiCore5.Model;
using ApiCore5.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using ApiCore5.Repository;
using ApiCore5.Repository.Implementations;

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
               return _repository.Insert(person);               
                

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(int id)
        {
            _repository.Delete(new Person() { Id = id});
           
        }

        public IEnumerable<Person> Get()
        {

            return _repository.GetAll();
        }        

        public Person Get(int id)
        {
            return _repository.GetPerson(p => p.Id == id);
        }

        public Person Update(Person person)
        {
           return _repository.Update(person);
        }

        

       

        

        
    }
}
