using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FlowerStore.Infrastructure.Data.Seed;

namespace FlowerStore.Infrastructure.Data.Seed.EntitiesConfiguration.RolesConfiguration
{
    internal class UserConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            var data = new DataSeed();

            builder.HasData(new IdentityUser[] { data.AdministratorUser, data.GuestUser });
        }
    }
}