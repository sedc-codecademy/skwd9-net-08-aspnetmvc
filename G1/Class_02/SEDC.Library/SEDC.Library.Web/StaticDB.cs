using SEDC.Library.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.Library.Web
{
    public static class StaticDB
    {
        public static List<Book> Books = new List<Book>
        {
            new Book
            {
                Id = 1,
                Title = "Harry Potter and the goblet of fire"
            },
            new Book
            {
                Id = 2,
                Title = "Lord of the rings the return of the king"
            },
            new Book
            {
                Id = 3,
                Title = "Volshebnoto samarche"
            },
        };
    }
}
