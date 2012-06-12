using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class PersonController : ApiController
    {
        private PersonRepository personRepository;

        public PersonController()
        {
            personRepository = new PersonRepository();
        }

        public Person GetPerson(long? id)
        {
            if (id.HasValue)
            {
                var person = personRepository.GetPersonById(id.Value);
                if (person != null)
                    return person;
            }
            throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        public Person PostPerson(Person person)
        {
            var newPerson = personRepository.AddPerson(person);
            if(newPerson != null)
            {
                return newPerson;
            }
            throw  new HttpResponseException(HttpStatusCode.InternalServerError);
        }

        public IEnumerable<Person> ListPersons()
        {
            return personRepository.GetAllPersons();
        }

    }
}
