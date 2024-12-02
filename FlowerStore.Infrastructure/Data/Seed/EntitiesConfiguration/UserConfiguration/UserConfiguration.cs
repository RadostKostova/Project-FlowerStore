using FlowerStore.Infrastructure.Data.Models.Roles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowerStore.Infrastructure.Data.Seed.EntitiesConfiguration.RolesConfiguration
{
    internal class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var data = new DataSeed();

            builder.HasData(new ApplicationUser[] { data.AdminUser, data.GuestUser, data.TestUser, data.RandomUser });
        }
    }
}