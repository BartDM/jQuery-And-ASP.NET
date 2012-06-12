using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webform.Object
{
    public class Person
    {
        public long PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Ticket> Tickets { get; set; }
    }

    public class Ticket
    {
        public long TickedId { get; set; }
        public string TicketName { get; set; }
    }
}