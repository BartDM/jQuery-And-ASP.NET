using System.Collections.Generic;
using System.Linq;
using Demo.Model;

namespace Demo
{
    public class PersonRepository
    {
        private List<Person> persons = new List<Person>()
                                           {
                                               new Person(){FirstName = "Bart",LastName = "De Meyer", Id=1},
                                               new Person(){FirstName = "Wouter",LastName = "Benoit", Id=2},
                                               new Person(){FirstName = "Sven",LastName = "Bru", Id=3},
                                               new Person(){FirstName = "Bram",LastName = "Van Espen", Id=4},
                                               new Person(){FirstName = "Eve",LastName = "Ravignot", Id=5}
                                           }; 

        
        public Person GetPersonById(long id)
        {
            return persons.FirstOrDefault(p => p.Id == id);
        }

        public Person AddPerson(Person person)
        {
            person.Id = GetNewId();
            persons.Add(person);
            return person;
        }

        private long GetNewId()
        {
            long id = persons.Max(t => t.Id);
            id++;
            return id;
        }

        public Person UpdatePerson(long id, Person person)
        {
            var personToUpdate = persons.FirstOrDefault(p => p.Id == id);
            if(person != null)
            {
                personToUpdate = person;
                return personToUpdate;
            }
            return null;
        }

        public void RemovePerson(long id)
        {
            persons.RemoveAll(p => p.Id == id);
        }
    }
}