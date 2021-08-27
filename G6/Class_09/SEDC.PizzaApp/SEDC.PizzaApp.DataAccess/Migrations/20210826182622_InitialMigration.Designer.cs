﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SEDC.PizzaApp.DataAccess;

namespace SEDC.PizzaApp.DataAccess.Migrations
{
    [DbContext(typeof(PizzaDbContext))]
    [Migration("20210826182622_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SEDC.PizzaApp.Domain.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SEDC.PizzaApp.Domain.Models.Pizza", b =>
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
                            Size = 1
                        },
                        new
                        {
                            Id = 2,
                            Image = "Kapri.png",
                            Name = "Kapri",
                            Price = 7.0,
                            Size = 2
                        },
                        new
                        {
                            Id = 3,
                            Image = "Kapri.png",
                            Name = "Kapri",
                            Price = 7.0,
                            Size = 3
                        },
                        new
                        {
                            Id = 4,
                            Image = "Peperoni.png",
                            Name = "Peperoni",
                            Price = 9.0,
                            Size = 1
                        },
                        new
                        {
                            Id = 5,
                            Image = "Peperoni.png",
                            Name = "Peperoni",
                            Price = 8.0,
                            Size = 2
                        },
                        new
                        {
                            Id = 6,
                            Image = "Peperoni.png",
                            Name = "Peperoni",
                            Price = 8.0,
                            Size = 3
                        },
                        new
                        {
                            Id = 7,
                            Image = "Margarita.png",
                            Name = "Margarita",
                            Price = 10.5,
                            Size = 1
                        },
                        new
                        {
                            Id = 8,
                            Image = "Margarita.png",
                            Name = "Margarita",
                            Price = 10.5,
                            Size = 2
                        },
                        new
                        {
                            Id = 9,
                            Image = "Margarita.png",
                            Name = "Margarita",
                            Price = 10.5,
                            Size = 3
                        },
                        new
                        {
                            Id = 10,
                            Image = "Siciliana.png",
                            Name = "Siciliana",
                            Price = 6.5,
                            Size = 1
                        },
                        new
                        {
                            Id = 11,
                            Image = "Siciliana.png",
                            Name = "Siciliana",
                            Price = 9.5,
                            Size = 2
                        },
                        new
                        {
                            Id = 12,
                            Image = "Siciliana.png",
                            Name = "Siciliana",
                            Price = 9.5,
                            Size = 3
                        });
                });

            modelBuilder.Entity("SEDC.PizzaApp.Domain.Models.PizzaOrder", b =>
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
                });

            modelBuilder.Entity("SEDC.PizzaApp.Domain.Models.User", b =>
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

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SEDC.PizzaApp.Domain.Models.Order", b =>
                {
                    b.HasOne("SEDC.PizzaApp.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SEDC.PizzaApp.Domain.Models.PizzaOrder", b =>
                {
                    b.HasOne("SEDC.PizzaApp.Domain.Models.Order", "Order")
                        .WithMany("PizzaOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SEDC.PizzaApp.Domain.Models.Pizza", "Pizza")
                        .WithMany()
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("SEDC.PizzaApp.Domain.Models.Order", b =>
                {
                    b.Navigation("PizzaOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
