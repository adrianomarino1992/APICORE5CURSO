using ApiCore5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiCore5.Services.Implementations
{
    public class PersonService : IPersonService
    {
        private volatile int id_conunt;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(int id)
        {

        }

        public IEnumerable<Person> Get()
        {
            List<Person> persons = new List<Person>();

            for (int i = 0; i < 10; i++)
            {
                persons.Add(MockPerson());
            }

            return persons;
        }        

        public Person Get(int id)
        {
            return MockPerson();
        }

        public Person Update(Person person)
        {
            return person;
        }


        private Person MockPerson()
        {
            Person person = null;

            person = new Person()
            {
                Id = GetAndIncrement(),
                FirstName = "Person name",
                LastName = "Person lastName",
                Address = "Person address"
            };

            return person;

        }

        private int GetAndIncrement()
        {
            return Interlocked.Increment(ref id_conunt);
        }
    }
}
