using FlowerStore.Infrastructure.Data.Models.Payment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowerStore.Infrastructure.Data.Seed.EntitiesConfiguration
{
    /// <summary>
    /// Configure and seed data for PaymentMethod entity. Default should be "Cash".
    /// </summary>

    internal class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            var data = new DataSeed();

            builder.HasData(new PaymentMethod[] { data.Cash, data.Card });
        }
    }
}
