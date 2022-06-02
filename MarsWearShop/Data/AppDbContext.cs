using MarsWearShop.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsWearShop.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Img> Imgs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderData> OrderDatas { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get;set; }
        public DbSet<UserOrderData> UserOrderDatas { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderStatus>().HasAlternateKey(x => x.Name);
            modelBuilder.Entity<Size>().HasAlternateKey(x => x.Name);
            modelBuilder.Entity<Role>().HasAlternateKey(x => x.Name);
            modelBuilder.Entity<User>().HasAlternateKey(x => x.Login);

            modelBuilder.Entity<Product>().Property(x => x.CurrPrice).HasComputedColumnSql("CONVERT([INT], [FullPrice] / 100.00 * (100 - [DiscountProcent]))", true);

            modelBuilder.Entity<Category>().HasData(DbInitializer.Categories);
            modelBuilder.Entity<Size>().HasData(DbInitializer.Sizes);
            modelBuilder.Entity<Product>().HasData(DbInitializer.Products);
            modelBuilder.Entity<Img>().HasData(DbInitializer.Imgs);
            modelBuilder.Entity<ProductCategory>().HasData(DbInitializer.ProductCategories);
            modelBuilder.Entity<ProductSize>().HasData(DbInitializer.ProductSizes);
            modelBuilder.Entity<Role>().HasData(DbInitializer.Roles);
            modelBuilder.Entity<User>().HasData(DbInitializer.Users);

            base.OnModelCreating(modelBuilder);
        }
    }
}
