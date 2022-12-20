using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ShopEntity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopEntity
    {
    public class Db:DbContext
        {
        DeleteBehavior behavior = DeleteBehavior.NoAction;

        SqlConnectionStringBuilder sqb = new() {
        DataSource = "localhost",
            InitialCatalog = "EntityShop",
            IntegratedSecurity=true,
            TrustServerCertificate=true };



        public Db()
            {
            Database.EnsureDeleted();
            Database.EnsureCreated();



            }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
            optionsBuilder.UseSqlServer(sqb.ConnectionString);
            }

        public DbSet<Category> Categorys { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shop> Shops { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            /*Составной первичный ключ для таблицы manyToMany*/
            modelBuilder.Entity<OrderProduct>().
            HasKey(q => new { q.OrderId, q.ProductId });




/*
            modelBuilder.Entity<Shop>().
            HasMany<Category>(q=>q.Categorys).
            WithOne(w=>w.Shop).
            OnDelete(behavior);


            modelBuilder.Entity<Product>().
            HasOne<Category>(p=>p.Category)
            .WithMany(c=>c.Products)
            .OnDelete(behavior);

            modelBuilder.Entity<Product>().
           HasMany<OrderProduct>(p=>p.OrderProducts)
           .WithOne(c => c.Product)
           .OnDelete(behavior);

           modelBuilder.Entity<Order>().
           HasOne<Customer>(o=>o.Customer).
           WithMany(c=>c.Orders).
           OnDelete(behavior);

            modelBuilder.Entity<Order>().
            HasOne<Employee>(o => o.Employee).
            WithMany(e => e.Orders).
            OnDelete(behavior);

            modelBuilder.Entity<Order>().
           HasMany<OrderProduct>(o => o.OrderProducts).
           WithOne(e => e.Order).
           OnDelete(behavior);*/



            }

        }
    }
