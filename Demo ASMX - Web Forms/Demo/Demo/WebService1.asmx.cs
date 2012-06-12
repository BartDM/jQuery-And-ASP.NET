using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Demo
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://bartdemeyer.be/Demo/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        private static string sessionName = "BookTitles";

        [WebMethod(EnableSession = true)]
        public long AddBook(string bookTitle)
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
            Book book = new Book() { BooktitleId = GetNextBookTitleId(), BookTitle = bookTitle };
            books.Add(book);
            Session[sessionName] = books;
            return book.BooktitleId;
        }

        /// <summary>
        /// Helper methode om een id voor een boek titel te 'berekenen'
        /// </summary>
        /// <returns></returns>
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
