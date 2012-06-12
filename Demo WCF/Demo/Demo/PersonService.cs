using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using Demo.Model;

namespace Demo
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class PersonService:IPersonService
    {
        private PersonRepository personRepository;

        public PersonService()
        {
            personRepository = new PersonRepository();
        }

        #region Implementation of IPersonService

        [WebGet(UriTemplate = "Person({id})")]
        public Person GetPerson(string id)
        {
            long personId;
            if(long.TryParse(id, out personId))
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
                return personRepository.UpdatePerson(personId,person);
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
        #endregion
    }
}