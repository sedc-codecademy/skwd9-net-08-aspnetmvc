﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SEDC.PizzApp.DataAccess;

namespace SEDC.PizzApp.DataAccess.Migrations
{
    [DbContext(typeof(PizzaDbContext))]
    partial class PizzaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SEDC.PizzApp.Domain.Models.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("SEDC.PizzApp.Domain.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Price = 0.0,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Price = 0.0,
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            Price = 0.0,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("SEDC.PizzApp.Domain.Models.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Pizzas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Image = "Kapri.png",
                            Name = "Kapri",
                            Price = 7.0,
                            Size = 0
                        },
                        new
                        {
                            Id = 2,
                            Image = "Kapri.png",
                            Name = "Kapri",
                            Price = 7.0,
                            Size = 1
                        },
                        new
                        {
                            Id = 3,
                            Image = "Kapri.png",
                            Name = "Kapri",
                            Price = 7.0,
                            Size = 2
                        },
                        new
                        {
                            Id = 4,
                            Image = "Peperoni.png",
                            Name = "Peperoni",
                            Price = 9.0,
                            Size = 0
                        },
                        new
                        {
                            Id = 5,
                            Image = "Peperoni.png",
                            Name = "Peperoni",
                            Price = 8.0,
                            Size = 1
                        },
                        new
                        {
                            Id = 6,
                            Image = "Peperoni.png",
                            Name = "Peperoni",
                            Price = 8.0,
                            Size = 2
                        },
                        new
                        {
                            Id = 7,
                            Image = "Margarita.png",
                            Name = "Margarita",
                            Price = 10.5,
                            Size = 0
                        },
                        new
                        {
                            Id = 8,
                            Image = "Margarita.png",
                            Name = "Margarita",
                            Price = 10.5,
                            Size = 1
                        },
                        new
                        {
                            Id = 9,
                            Image = "Margarita.png",
                            Name = "Margarita",
                            Price = 10.5,
                            Size = 2
                        },
                        new
                        {
                            Id = 10,
                            Image = "Siciliana.png",
                            Name = "Siciliana",
                            Price = 6.5,
                            Size = 0
                        },
                        new
                        {
                            Id = 11,
                            Image = "Siciliana.png",
                            Name = "Siciliana",
                            Price = 9.5,
                            Size = 1
                        },
                        new
                        {
                            Id = 12,
                            Image = "Siciliana.png",
                            Name = "Siciliana",
                            Price = 9.5,
                            Size = 2
                        });
                });

            modelBuilder.Entity("SEDC.PizzApp.Domain.Models.PizzaOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("PizzaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("PizzaId");

                    b.ToTable("PizzaOrder");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OrderId = 1,
                            PizzaId = 1
                        },
                        new
                        {
                            Id = 2,
                            OrderId = 1,
                            PizzaId = 4
                        },
                        new
                        {
                            Id = 3,
                            OrderId = 2,
                            PizzaId = 1
                        },
                        new
                        {
                            Id = 4,
                            OrderId = 2,
                            PizzaId = 5
                        },
                        new
                        {
                            Id = 5,
                            OrderId = 2,
                            PizzaId = 7
                        },
                        new
                        {
                            Id = 6,
                            OrderId = 3,
                            PizzaId = 5
                        },
                        new
                        {
                            Id = 7,
                            OrderId = 3,
                            PizzaId = 9
                        },
                        new
                        {
                            Id = 8,
                            OrderId = 3,
                            PizzaId = 12
                        });
                });

            modelBuilder.Entity("SEDC.PizzApp.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Phone")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Bob Street",
                            FirstName = "Bob",
                            LastName = "Bobsky",
                            Phone = 80012312345L
                        },
                        new
                        {
                            Id = 2,
                            Address = "Jill Street",
                            FirstName = "Jill",
                            LastName = "Wayne",
                            Phone = 8006546345L
                        });
                });

            modelBuilder.Entity("SEDC.PizzApp.Domain.Models.Order", b =>
                {
                    b.HasOne("SEDC.PizzApp.Domain.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SEDC.PizzApp.Domain.Models.PizzaOrder", b =>
                {
                    b.HasOne("SEDC.PizzApp.Domain.Models.Order", "Order")
                        .WithMany("PizzaOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SEDC.PizzApp.Domain.Models.Pizza", "Pizza")
                        .WithMany("PizzaOrders")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("SEDC.PizzApp.Domain.Models.Order", b =>
                {
                    b.Navigation("PizzaOrders");
                });

            modelBuilder.Entity("SEDC.PizzApp.Domain.Models.Pizza", b =>
                {
                    b.Navigation("PizzaOrders");
                });

            modelBuilder.Entity("SEDC.PizzApp.Domain.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
