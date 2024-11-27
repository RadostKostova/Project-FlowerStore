using FlowerStore.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowerStore.Infrastructure.Data.Seed.EntitiesConfiguration
{
    /// <summary>
    /// Configuration for Product entity. Will be seeded with initial data.
    /// </summary>

    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            var data = new DataSeed();

            builder.HasData(new Product[]
            {
                data.RedRoses,
                data.BlueOrchid,
                data.FicusLyrata,
                data.OrangeTagetes,
                data.PinkBegonia,
                data.RedBegonia,
                data.WhiteAnthurium,
                data.YellowBegonia,
                data.PinkGeranium,
                data.PurpleAgeratum,
                data.RedGeranium,
                data.PinkPetunias,
                data.PurplePelargonium,
                data.WhiteGeranium,
                data.PinkHibiscus
            });
        }
    }
}
