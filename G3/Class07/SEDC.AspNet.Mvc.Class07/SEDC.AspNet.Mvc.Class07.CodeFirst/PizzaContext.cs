using Microsoft.EntityFrameworkCore;
using SEDC.AspNet.Mvc.Class07.CodeFirst.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.AspNet.Mvc.Class07.CodeFirst
{
    public class PizzaContext : DbContext
    {
        public PizzaContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<NewsletterSubscription> Subscriptions { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
