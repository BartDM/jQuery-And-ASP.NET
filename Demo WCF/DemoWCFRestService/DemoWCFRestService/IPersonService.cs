using System.ServiceModel;
using DemoWCFRestService.Models;

namespace DemoWCFRestService
{
    [ServiceContract]
    interface IPersonService
    {
        [OperationContract]
        Person GetPerson(string id);

        [OperationContract]
        Person InsertPerson(Person person);

        [OperationContract]
        Person UpdatePerson(string id, Person person);

        [OperationContract]
        void DeletePerson(string id);
    }
}
