using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Webform.Object;

namespace Webform
{
    public partial class Webform : System.Web.UI.Page
    {
        private static string sessionName = "TicketsWebmethod";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod(EnableSession = true)]
        public static Ticket AddTicket(string ticketName)
        {
            List<Ticket> tickets;
            if(HttpContext.Current.Session[sessionName]!= null)
            {
                tickets = HttpContext.Current.Session[sessionName] as List<Ticket>;
                if(tickets==null)
                    tickets = new List<Ticket>();
            }
            else
            {
                tickets = new List<Ticket>();
            }
            Ticket ticket = new Ticket() {TickedId = GetNextTicketId(),TicketName = ticketName};
            tickets.Add(ticket);
            HttpContext.Current.Session[sessionName] = tickets;
            return ticket;
        }

        private static long GetNextTicketId()
        {
            if (HttpContext.Current.Session[sessionName] != null)
            {
                List<Ticket> tickets = HttpContext.Current.Session[sessionName] as List<Ticket>;
                if (tickets != null)
                {
                    long ticket = tickets.Max(t => t.TickedId);
                    ticket++;
                    return ticket;
                }
            }
            return 1;
        }

    }
}