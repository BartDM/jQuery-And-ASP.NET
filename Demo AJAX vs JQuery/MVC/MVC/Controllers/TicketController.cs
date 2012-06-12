using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class TicketController : Controller
    {
        private static string sessionName = "TicketsWebmethod";

        //
        // GET: /Ticket/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTicket(string ticketName)
        {
            List<Ticket> tickets;
            if (Session[sessionName] != null)
            {
                tickets = Session[sessionName] as List<Ticket>;
                if (tickets == null)
                    tickets = new List<Ticket>();
            }
            else
            {
                tickets = new List<Ticket>();
            }
            Ticket ticket = new Ticket() { TickedId = GetNextTicketId(), TicketName = ticketName };
            tickets.Add(ticket);
            Session[sessionName] = tickets;

            return Json(ticket, JsonRequestBehavior.AllowGet);

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
