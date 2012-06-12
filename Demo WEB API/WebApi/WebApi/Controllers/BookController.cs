using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class BookController : ApiController
    {
        public IEnumerable<Book> ListBooks()
        {
            return new List<Book>()
                       {
                           new Book()
                               {
                                   Added = new DateTime(2012,1,1),Author = "Author 1",ISBN = "123456789",Id = 1,Pages = 235,PrintDate = new DateTime(1990,5,2),Title = "Dit is een boek 1",UserName = "Bart De Meyer"
                               },
                           new Book()
                               {
                                   Added = new DateTime(2012,1,1),Author = "Author 2",ISBN = "123456789",Id = 2,Pages = 235,PrintDate = new DateTime(1990,5,2),Title = "Dit is een boek 2",UserName = "Bart De Meyer"
                               }
                       };
        }

    }
}
