using FlowerStore.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowerStore.Infrastructure.Data.Seed.EntitiesConfiguration
{
    internal class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        /// <summary>
        /// Seeding configuration for reviews
        /// </summary>

        public void Configure(EntityTypeBuilder<Review> builder)
        {
            var data = new DataSeed();

            builder.HasData(new Review[] { data.FirstReview, data.SecondReview, data.ThirdReview });
        }
    }
}
