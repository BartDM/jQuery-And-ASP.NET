using System.Collections.Generic;
using System.Linq;
using DemoWCFRestService.Models;

namespace DemoWCFRestService
{
    public class PersonRepository
    {
        private List<Person> persons = new List<Person>()
                                           {
                                               new Person(){FirstName = "FirstName1",LastName = "LastName1", Id=1},
                                               new Person(){FirstName = "FirstName2",LastName = "LastName2", Id=2},
                                               new Person(){FirstName = "FirstName3",LastName = "LastName3", Id=3},
                                               new Person(){FirstName = "FirstName4",LastName = "LastName4", Id=4},
                                               new Person(){FirstName = "FirstName5",LastName = "LastName5", Id=5}
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
            if (person != null)
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