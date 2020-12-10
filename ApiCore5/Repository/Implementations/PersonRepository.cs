using ApiCore5.Model;
using ApiCore5.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace ApiCore5.Repository.Implementations
{
    public class PersonRepository : IPersonRepository
    {
        private MySqlContext _context;

        public PersonRepository(MySqlContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Persons.Add(person);
                _context.SaveChanges();
                return person;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(int id)
        {
            Person p = _context.Persons.Where(p => p.Id == id).Select(p => p).FirstOrDefault();

            if (PersonExists(person: p))
            {
                try
                {
                    _context.Persons.Remove(p);
                    _context.SaveChanges();                    

                }
                catch (Exception)
                {
                    throw;
                }

            }
           
        }

        public IEnumerable<Person> Get()
        {
           
            return _context.Persons.ToList();
        }        

        public Person Get(int id)
        {
            return _context.Persons.Where(p => p.Id == id).Select(p => p).FirstOrDefault();
        }

        public Person Update(Person person)
        {
           if(PersonExists(person : person))
            {
                try
                {
                    _context.Persons.Update(person);
                    _context.SaveChanges();

                    return person;

                }
                catch(Exception)
                {
                    throw;
                }
               
            }
            else
            {
                return new Person();
            }
        }

        private bool PersonExists(int? id = null, Person person = null)
        {
            if(_context.Persons.Count(p => p.Id == id || p.Id == person.Id) > 0)
            {
                return true;
            }
            return false;
        }

       

        

        
    }
}
