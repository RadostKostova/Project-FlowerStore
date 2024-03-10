using FlowerStore.Infrastructure.Data.Models.Orders.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowerStore.Infrastructure.Data.Seed.EntitiesConfiguration
{
    /// <summary>
    /// Configuration and data seeding for OrderStatus entity. Seed data with statuses.
    /// </summary>

    internal class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            var data = new DataSeed();

            builder.HasData(new OrderStatus[] { data.Pending, data.Shipped, data.Delivered });
        }
    }
}
