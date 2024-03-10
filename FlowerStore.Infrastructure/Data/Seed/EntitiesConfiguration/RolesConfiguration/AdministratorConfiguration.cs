using BookingSystem.Infrastructure.Data.Models.Roles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowerStore.Infrastructure.Data.Seed.EntitiesConfiguration.RolesConfiguration
{
    internal class AdministratorConfiguration : IEntityTypeConfiguration<Administrator>
    {
        public void Configure(EntityTypeBuilder<Administrator> builder)
        {
            var data = new DataSeed();

            builder.HasData(new Administrator[] { data.Administrator });
        }
    }
}
