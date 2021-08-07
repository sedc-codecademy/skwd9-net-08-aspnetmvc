using SEDC.LibraryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.LibraryApp
{
    public static class StaticDb
    {
        public static List<Book> Books = new List<Book>
        {
            new Book
            {
                Id = 1,
                Title = "Zoki Poki"
            },
            new Book
            {
                Id = 2,
                Title = "Kasni Porasni"
            }
        };
    }
}
