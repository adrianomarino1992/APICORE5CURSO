using ApiCore5.Model;
using ApiCore5.Model.Context;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using ApiCore5.Business;

namespace ApiCore5.Repository.Implementations
{
    public class PersonRepository : IPersonRepository
    {
        private MySqlContext _context;

        private DbSet<Person> _dbSet;


        /// <summary>
        /// Contructor using Dependecy Injection
        /// </summary>
        /// <param name="context" Type="Microsoft.EntityFrameworkCore.DbContext"></param>
        public PersonRepository(MySqlContext context) {

            _context = context;
        
        }

        #region metodos_especializacao_interface IPersonRepository


        public Person GetPerson(Expression<Func<Person,bool>> query)
        {
            try
            {
                return _context.Persons.Where(query).FirstOrDefault();
                    
            }
            catch
            {
                return null;
            }
        }


        #endregion



        #region metodos_interface

        /*
         * implementação da interface IRepository
         * 
         */
        public Person Delete(Person obj)
        {
            Person result = _context.Persons.FirstOrDefault(o => o.Id == obj.Id) as Person;

            if (result == null) return null;


            try
            {
                _context.Persons.Remove(obj);
                _context.SaveChanges();
                return obj;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<Person> GetAll()
        {
            try
            {
                return _context.Persons
                    .OrderBy(p => p.FirstName)
                    .Select(o => o).ToList();
            }
            catch
            {
                return null;
            }
        }

        public Person Insert(Person obj)
        {
            try
            {
                _context.Persons.Add(obj);
                _context.SaveChanges();
                return obj;
            }
            catch
            {
                return null;
            }
        }

        public Person Update(Person obj)
        {
            Person result = _context.Persons.FirstOrDefault(o => o.Id == obj.Id) as Person;

            if (result == null) return null;
           

            try
            {
                _context.Persons.Update(obj);
                _context.SaveChanges();
                return obj;
            }
            catch
            {
                return null;
            }
        }

        #endregion
    }
}
