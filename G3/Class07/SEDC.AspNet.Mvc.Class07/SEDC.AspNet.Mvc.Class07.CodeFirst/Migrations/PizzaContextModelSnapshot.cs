﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SEDC.AspNet.Mvc.Class07.CodeFirst;

namespace SEDC.AspNet.Mvc.Class07.CodeFirst.Migrations
{
    [DbContext(typeof(PizzaContext))]
    partial class PizzaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SEDC.AspNet.Mvc.Class07.CodeFirst.Models.DomainModels.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Temnica"
                        });
                });

            modelBuilder.Entity("SEDC.AspNet.Mvc.Class07.CodeFirst.Models.DomainModels.NewsletterSubscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsSubscribed")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Subscriptions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsSubscribed = true
                        });
                });

            modelBuilder.Entity("SEDC.AspNet.Mvc.Class07.CodeFirst.Models.DomainModels.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Delivered")
                        .HasColumnType("bit");

                    b.Property<int?>("PizzaId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PizzaId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SEDC.AspNet.Mvc.Class07.CodeFirst.Models.DomainModels.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                            Name = "Kapri",
                            Price = 7.0,
                            Size = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Kapri",
                            Price = 8.0,
                            Size = 2
                        },
                        new
                        {
                            Id = 3,
                            Name = "Kapri",
                            Price = 9.0,
                            Size = 3
                        });
                });

            modelBuilder.Entity("SEDC.AspNet.Mvc.Class07.CodeFirst.Models.DomainModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<long>("Phone")
                        .HasColumnType("bigint");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.HasIndex("SubscriptionId")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressId = 1,
                            FirstName = "Trajan",
                            LastName = "Stevkovski",
                            Phone = 123432123L,
                            SubscriptionId = 1
                        });
                });

            modelBuilder.Entity("SEDC.AspNet.Mvc.Class07.CodeFirst.Models.DomainModels.Order", b =>
                {
                    b.HasOne("SEDC.AspNet.Mvc.Class07.CodeFirst.Models.DomainModels.Pizza", "Pizza")
                        .WithMany()
                        .HasForeignKey("PizzaId");

                    b.HasOne("SEDC.AspNet.Mvc.Class07.CodeFirst.Models.DomainModels.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SEDC.AspNet.Mvc.Class07.CodeFirst.Models.DomainModels.User", b =>
                {
                    b.HasOne("SEDC.AspNet.Mvc.Class07.CodeFirst.Models.DomainModels.Address", "Address")
                        .WithOne("User")
                        .HasForeignKey("SEDC.AspNet.Mvc.Class07.CodeFirst.Models.DomainModels.User", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SEDC.AspNet.Mvc.Class07.CodeFirst.Models.DomainModels.NewsletterSubscription", "Subscription")
                        .WithOne("User")
                        .HasForeignKey("SEDC.AspNet.Mvc.Class07.CodeFirst.Models.DomainModels.User", "SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
