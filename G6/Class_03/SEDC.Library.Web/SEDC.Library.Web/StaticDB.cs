using SEDC.Library.Web.Models;
using System;
using System.Collections.Generic;

namespace SEDC.Library.Web
{
    public static class StaticDB
    {
        public static List<Book> Books = new List<Book>()
        {
            new Book
            {
                Id = 1,
                Title = "Harry potter 1",
                AuthorId = 1,
                PublishingHouseId = 1
            },
            new Book
            {
                Id = 2,
                Title = "Harry potter 2",
                AuthorId = 1,
                PublishingHouseId = 1
            },
            new Book
            {
                Id = 3,
                Title = "Harry potter 3",
                AuthorId = 1,
                PublishingHouseId = 1
            }
        };

        public static List<Author> Authors = new List<Author>()
        {
            new Author
            {
                Id = 1,
                Name = "Joanne K. Rowling",
                DateOfBirth = Convert.ToDateTime("1965/07/31")
            }
        };

        public static List<PublishingHouse> PublishingHouses = new List<PublishingHouse>()
        {
            new PublishingHouse
            {
                Id = 1,
                Name = "Bloomsbury Publishing"
            }
        };
    }
}
