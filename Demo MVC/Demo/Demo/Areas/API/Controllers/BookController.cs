using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Demo.Models;

namespace Areas.API.Controllers
{
    public class BookController : Controller
    {
        private static string sessionName = "BooksSessionName";

        public ActionResult AddBook(string bookTitle)
        {
            List<Book> books;
            if (Session[sessionName] != null)
            {
                books = Session[sessionName] as List<Book>;
                if (books == null)
                    books = new List<Book>();
            }
            else
            {
                books = new List<Book>();
            }
            Book book = new Book() { BookId = GetNextBookTitleId(), BookTitle = bookTitle };
            books.Add(book);
            Session[sessionName] = books;
            return Json(book, JsonRequestBehavior.AllowGet);
        }

        private long GetNextBookTitleId()
        {
            if (Session[sessionName] != null)
            {
                List<Book> books = Session[sessionName] as List<Book>;
                if (books != null)
                {
                    long ticket = books.Max(t => t.BookId);
                    ticket++;
                    return ticket;
                }
            }
            return 1;
        }
    }
}
