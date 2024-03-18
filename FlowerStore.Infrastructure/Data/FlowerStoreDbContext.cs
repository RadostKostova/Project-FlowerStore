using BookingSystem.Infrastructure.Data.Models.Roles;
using FlowerStore.Infrastructure.Data.Models;
using FlowerStore.Infrastructure.Data.Models.Cart;
using FlowerStore.Infrastructure.Data.Models.Carts;
using FlowerStore.Infrastructure.Data.Models.Orders.Order;
using FlowerStore.Infrastructure.Data.Models.Payment;
using FlowerStore.Infrastructure.Data.Seed.EntitiesConfiguration;
using FlowerStore.Infrastructure.Data.Seed.EntitiesConfiguration.RolesConfiguration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FlowerStore.Infrastructure.Data
{
    public class FlowerStoreDbContext : IdentityDbContext
    {
        /// <summary>
        /// Declaring DBSets and configuration with initial data seeding.
        /// </summary>
        public FlowerStoreDbContext(DbContextOptions<FlowerStoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<CardDetails> CardDetails { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartProduct> ShoppingCartProducts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {            
            builder.Entity<Order>()
                .Property(o => o.TotalPrice)
                .HasPrecision(18, 2);       //HasColumnType("decimal(18, 2)")

            builder.Entity<OrderProduct>()
                .Property(op => op.UnitPrice)
                .HasPrecision(18, 2);

            builder.Entity<ShoppingCartProduct>()
                .Property(shp => shp.Price)
                .HasPrecision(18, 2);

            builder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);

            //Mapping entities (tables)
            builder.Entity<ShoppingCartProduct>()
                .HasKey(psc => new { psc.ProductId, psc.ShoppingCartId });

            builder.Entity<OrderProduct>()
                .HasKey(op => new { op.ProductId, op.OrderId });

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new AdministratorConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new PaymentMethodConfiguration());
            builder.ApplyConfiguration(new OrderStatusConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
