using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SEDC.AspNet.Mvc.PizzaApp.Domain.Models;

namespace SEDC.AspNet.Mvc.PizzaApp.DataAccess.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable("Users")
                .HasKey(x => x.Id);

            builder
                .Property(p => p.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(p => p.LastName)
                .HasMaxLength(50);

            builder
                .Property(p => p.Address)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .HasMany(x => x.Orders)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
        }
    }
}
