using System.ServiceModel.Web;
using DemoWCFRestService.Models;

namespace DemoWCFRestService
{
    public class PersonsService : IPersonService
    {
        private PersonRepository personRepository;

        public PersonsService()
        {
            personRepository = new PersonRepository();
        }

        [WebGet(UriTemplate = "Person({id})")]
        public Person GetPerson(string id)
        {
            long personId;
            if (long.TryParse(id, out personId))
            {
                return personRepository.GetPersonById(personId);
            }
            return null;
        }

        [WebInvoke(UriTemplate = "Person", Method = "POST")]
        public Person InsertPerson(Person person)
        {
            return personRepository.AddPerson(person);
        }

        [WebInvoke(UriTemplate = "Person({id})", Method = "PUT")]
        public Person UpdatePerson(string id, Person person)
        {
            long personId;
            if (long.TryParse(id, out personId))
            {
                return personRepository.UpdatePerson(personId, person);
            }
            return null;
        }

        [WebInvoke(UriTemplate = "Person({id})", Method = "DELETE")]
        public void DeletePerson(string id)
        {
            long personId;
            if (long.TryParse(id, out personId))
            {
                personRepository.RemovePerson(personId);
            }
        }
    }
}
