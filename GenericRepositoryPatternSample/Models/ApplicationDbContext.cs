using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericRepositoryPatternSample.Models
{
    class ApplicationDbContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ApplicationDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("ApplicationDb");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, CategoryName = "Clothes" },
                new Category { Id = 2, CategoryName = "Electronics" }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, ProductName = "T-Shirt", CategoryId = 1 },
                new Product { Id = 2, ProductName = "Pants", CategoryId = 1 },
                new Product { Id = 3, ProductName = "Laptop", CategoryId = 2 },
                new Product { Id = 4, ProductName = "TV", CategoryId = 2 }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
