using FlowerStore.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowerStore.Infrastructure.Data.Seed.EntitiesConfiguration
{
    /// <summary>
    /// Data seeding and coonfiguration for Category entity.
    /// </summary>

    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            var data = new DataSeed();

            builder.HasData(new Category[] 
            { 
                data.Tropical,
                data.Desert,
                data.Indoor,
                data.Outdoor,
                data.Wildflowers,
                data.Garden,
                data.Exotic,
                data.Native,
                data.Seasonal,
                data.Other
            });            
        }
    }
}

