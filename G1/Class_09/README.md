# Connecting to DataBase 🥞

Web applications change dynamically depending on the data that is requested. This makes accessing, managing and working with data an integral part of a web application. Data can be kept in different data structures, but a database is the most commonly used. An application can work with a database as long as it has the right address and authorization to work with that database. The thing that makes a difference is not connecting but how we manipulate and use the database from our application. In ASP.NET applications we can do that with:

- ADO.NET - system from the .NET framework that manages connecting and manipulating with a database. Used for manually opening/ closing connections to the database, as well as manipulating records by writing queries
- ORM framework - A system that does the communication between code and database automatic in a way ( easier to communicate )

## What is ORM 🔹

Object-relational mapping is the process where we create a relation between two types of data simpler and easier. In the case of a web application, we need our classes and logic to be understood and written in a database ( MSSQL ) which does not know how to communicate with our code ( C# ). To make things easier we use an object-relational mapping framework that can bridge this gap, so that we can easily write C# logic and update the database or the other way around. These frameworks usually have an abstract representation of the data structure so that it can serve both sides of the application.

## Entity Framework 🔹

One of the most popular object-relational mapping frameworks for .NET is Entity Framework. The framework works with ADO.NET in the background, meaning that we still use ADO.NET to make calls to a database, but it builds its own queries depending on what we request from it and how we change our code. Entity Framework comes with every ASP.NET MVC application already installed. With entity framework, we can approach the problem with connecting to a database by:

- Code First - Creating classes and connecting them so that the framework can create a database
- Database First - Creating a database and connecting everything so that from that the framework creates code structure ( classes )
- Model First - Create a model in a designer ( like diagram ) and from that the framework creates database and code structure ( classes )

The Code First is the most .NET friendly way of approaching database connection and it can be done by simply creating classes and a context. Entity framework looks at the classes and the context and makes a database from that. Every property becomes a column and every class a table. The relations have become keys and constraints. Keep in mind that the framework will not work if the code and the database get out of sync, so we must keep them sync when making changes directly to the database or in the domain classes.

### Context

The context is the code representation of our database. It is a special class that keeps track of what should be mapped into the database. The context is also a point of entry to the database, meaning that we use the context to add, delete, update and read from the database. Ex: If we add in the context a User and that User has 2 Orders, entity framework will take the info that we added into the context and try and add it to the database, one user column connected and 2 columns in order which are connected with one to many relationship. Relationships and configurations as well as adding data ( seeding ) to our database can be done through the context

```csharp
using Project.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Entity.Framework.Demo.Database
{
	// Must inherit from DbContext
    public class PizzaDbContext : DbContext
    {
	    // Configuring the context
        public PizzaDbContext(DbContextOptions options) : base(options){}
        public DbSet<Order> Orders { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        // Called upon database context initialization
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
	        // Configuring
            modelBuilder.Entity<Order>()
                .HasMany(x => x.Pizzas)
                .WithOne(x => x.Order);
            // Seeding
            modelBuilder.Entity<Order>().HasData(
                new Order()
                {
                    Id = 1,
                    Address = "Bobsky St",
                    Name = "Bob Bobsky",
                    Phone = "243243242"
                },
                new Order()
                {
                    Id = 2,
                    Address = "Jill St",
                    Name = "Jill Wayne",
                    Phone = "45345345"
                }
                );
            modelBuilder.Entity<Pizza>().HasData(
            new Pizza()
            {
                Id = 1,
                Name = "Kapri",
                Size = PizzaSize.Medium,
                OrderId = 1
            },
            new Pizza()
            {
                Id = 2,
                Name = "Peperoni",
                Size = PizzaSize.Family,
                OrderId = 1
            },
            new Pizza()
            {
                Id = 3,
                Name = "Peperoni",
                Size = PizzaSize.Family,
                OrderId = 2
            },
            new Pizza()
            {
                Id = 4,
                Name = "Siciliana",
                Size = PizzaSize.Medium,
                OrderId = 2
            }
            );
        }
    }
}

```

### Migrations

For entity framework to keep track of all the changes in our code and the database, it uses migrations. Migrations are basically change requests from the code to the database. Every time we change the domain models or the context we must create a migration, request that the database change accordingly. We do this with the NuGet Package Manager Console which can be found:

1. Tools
2. NuGet Package Manager
3. Package Manager Console
4. A console will open at the bottom of your visual studio instance

### Creating a database and migrations

In order for us to create a database first we need to create a migration. This is the first migration from which the database will be built. This migration is usually called something like init or with the word init to mark it as the first initial migration. After we do a migration, the migration is created in our project. Migrations in the project do not change the database. If we want to update the database with the latest migration we must write a command.

#### Add Migration Command

```cmd
add-migration Init
```

#### Update Database

```cmd
update-database
```

## Extra Materials 📘

- [Microsoft documentation on EF Core](https://docs.microsoft.com/en-us/ef/core/)
- [Getting Started with EF Core](https://www.learnentityframeworkcore.com/walkthroughs/aspnetcore-application)
