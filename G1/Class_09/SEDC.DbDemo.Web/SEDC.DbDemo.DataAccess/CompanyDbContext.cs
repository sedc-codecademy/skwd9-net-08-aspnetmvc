using Microsoft.EntityFrameworkCore;
using SEDC.DbDemo.Domain;

namespace SEDC.DbDemo.DataAccess
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions options) : base(options) { }


        public DbSet<Company> Companies { get; set; }

        public DbSet<Employee> Employees { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration of table relations in the database - by using FluentAPI

            // Configure one-to-many relation in the database

            modelBuilder.Entity<Company>()
                .HasMany(x => x.Employees)
                .WithOne(x => x.Company)
                .HasForeignKey(x => x.CompanyId);
        }

    }
}
