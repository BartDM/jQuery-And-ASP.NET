using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Models;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult Index2()
        {
            var books = new List<Book>()
                            {
                                new Book() {BookId = 1, BookTitle = "Test"},
                                new Book() {BookId = 2, BookTitle = "Test2"},
                                new Book() {BookId = 3, BookTitle = "Test3"}

                            };
            return View(books);
        }

        public ActionResult About()
        {
            return View();
        }

        private static string sessionName = "BooksSessionName";

        #region JSON controller methods

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
            return Json(book,JsonRequestBehavior.AllowGet);
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
    
        public ActionResult GetOrderedBooks()
        {
            List<Book> books = new List<Book>()
                                   {
                                       new Book() {BookId = 1, BookTitle = "Book 1"},
                                       new Book() {BookId = 2, BookTitle = "Book 2"},
                                       new Book() {BookId = 3, BookTitle = "Book 3"},
                                       new Book() {BookId = 4, BookTitle = "Book 4"}

                                   };
            return Json(books,JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
