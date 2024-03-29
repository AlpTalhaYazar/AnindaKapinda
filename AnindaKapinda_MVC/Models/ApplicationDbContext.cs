﻿using AnindaKapinda_MVC.Models.EntityConfiguration;
using AnindaKapinda_MVC.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnindaKapinda_MVC.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Employee> Employees { get; set; }        
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=AnindaKapinda;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CartEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CartProductEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CityEntityConfiguration());            
            modelBuilder.ApplyConfiguration(new ClientEntityConfiguration());            
            modelBuilder.ApplyConfiguration(new CreditCardEntityConfiguration()); 
            modelBuilder.ApplyConfiguration(new DistrictEntityConfiguration());           
            modelBuilder.ApplyConfiguration(new OrderProductEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
        }
    }
}
