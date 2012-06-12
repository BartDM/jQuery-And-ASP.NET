using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo
{
    public partial class _Default : System.Web.UI.Page
    {
        private static string sessionName = "BookTitles";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod(EnableSession = true)]
        public static long AddBook(string bookTitle)
        {
            List<Book> books;
            if (HttpContext.Current.Session[sessionName] != null)
            {
                books = HttpContext.Current.Session[sessionName] as List<Book>;
                if (books == null)
                    books = new List<Book>();
            }
            else
            {
                books = new List<Book>();
            }
            Book book = new Book() { BooktitleId = GetNextBookTitleId(), BookTitle = bookTitle };
            books.Add(book);
            HttpContext.Current.Session[sessionName] = books;
            return book.BooktitleId;
        }

        private static long GetNextBookTitleId()
        {
            if (HttpContext.Current.Session[sessionName] != null)
            {
                List<Book> books = HttpContext.Current.Session[sessionName] as List<Book>;
                if (books != null)
                {
                    long ticket = books.Max(t => t.BooktitleId);
                    ticket++;
                    return ticket;
                }
            }
            return 1;
        }
    }
}
