using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Webform.Object;

namespace Webform
{
    public partial class UpdatePanel : System.Web.UI.Page
    {
        private string sessionName = "Tickets";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Ticket ticket = new Ticket();
            ticket.TickedId = GetNextTicketId();
            ticket.TicketName = txtTicket.Text;
            List<Ticket> tickets;
            if (Session[sessionName] != null)
            {
                tickets = Session[sessionName] as List<Ticket>;
                if(tickets==null)
                {
                    tickets = new List<Ticket>();
                }
            }
            else
            {
                tickets = new List<Ticket>();
            }
            tickets.Add(ticket);
            Session[sessionName] = tickets;
            lstTickets.DataSource = tickets;
            lstTickets.DataBind();
            txtTicket.Text = string.Empty;
        }

        private long GetNextTicketId()
        {
            if (Session[sessionName] != null)
            {
                List<Ticket> tickets = Session[sessionName] as List<Ticket>;
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