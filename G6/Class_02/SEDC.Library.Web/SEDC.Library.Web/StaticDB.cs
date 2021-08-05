using SEDC.Library.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.Library.Web
{
    public static class StaticDB
    {
        public static List<Book> Books = new List<Book>()
        {
            new Book
            {
                Id = 1,
                Title = "Harry potter 1"
            },
            new Book
            {
                Id = 2,
                Title = "Harry potter 2"
            },
            new Book
            {
                Id = 3,
                Title = "Harry potter 3"
            }
        };

        
    }
}
