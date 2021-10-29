﻿// <auto-generated />
using System;
using AnindaKapinda_MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AnindaKapinda_MVC.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AnindaKapinda_MVC.Models.Address", b =>
                {
                    b.Property<int>("AddressID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ClientID")
                        .HasColumnType("int");

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressID");

                    b.HasIndex("ClientID");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("AnindaKapinda_MVC.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("AnindaKapinda_MVC.Models.Client", b =>
                {
                    b.Property<int>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmation")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("AnindaKapinda_MVC.Models.CreditCard", b =>
                {
                    b.Property<int>("CreditCardID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CardHolder")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ClientID")
                        .HasColumnType("int");

                    b.Property<string>("ExpirationDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CreditCardID");

                    b.HasIndex("ClientID");

                    b.ToTable("CreditCards");
                });

            modelBuilder.Entity("AnindaKapinda_MVC.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserRoleRoleID")
                        .HasColumnType("int");

                    b.HasKey("EmployeeID");

                    b.HasIndex("UserRoleRoleID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("AnindaKapinda_MVC.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DiscountRate")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("AnindaKapinda_MVC.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserRoleRoleID")
                        .HasColumnType("int");

                    b.HasKey("UserID");

                    b.HasIndex("UserRoleRoleID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AnindaKapinda_MVC.Models.UserRole", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleID");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("AnindaKapinda_MVC.Models.Address", b =>
                {
                    b.HasOne("AnindaKapinda_MVC.Models.Client", "Client")
                        .WithMany("Addresses")
                        .HasForeignKey("ClientID");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("AnindaKapinda_MVC.Models.CreditCard", b =>
                {
                    b.HasOne("AnindaKapinda_MVC.Models.Client", "Client")
                        .WithMany("CreditCards")
                        .HasForeignKey("ClientID");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("AnindaKapinda_MVC.Models.Employee", b =>
                {
                    b.HasOne("AnindaKapinda_MVC.Models.UserRole", "UserRole")
                        .WithMany()
                        .HasForeignKey("UserRoleRoleID");

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("AnindaKapinda_MVC.Models.Product", b =>
                {
                    b.HasOne("AnindaKapinda_MVC.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("AnindaKapinda_MVC.Models.User", b =>
                {
                    b.HasOne("AnindaKapinda_MVC.Models.UserRole", "UserRole")
                        .WithMany("Users")
                        .HasForeignKey("UserRoleRoleID");

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("AnindaKapinda_MVC.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("AnindaKapinda_MVC.Models.Client", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("CreditCards");
                });

            modelBuilder.Entity("AnindaKapinda_MVC.Models.UserRole", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
