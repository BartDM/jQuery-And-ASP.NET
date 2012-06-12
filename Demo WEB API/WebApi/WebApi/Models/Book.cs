using System;

namespace WebApi.Models
{
    public class Book
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int Pages { get; set; }
        public DateTime PrintDate { get; set; }
        public string UserName { get; set; }
        public DateTime Added { get; set; }
    }
}