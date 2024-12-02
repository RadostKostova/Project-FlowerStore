using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowerStore.Infrastructure.Data.Seed.EntitiesConfiguration.UserConfiguration
{
    public class UserClaimsConfiguration : IEntityTypeConfiguration<IdentityUserClaim<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> builder)
        {
            var data = new DataSeed();

            builder.HasData(data.AdminUserClaim, data.GuestUserClaim, data.TestUserClaim, data.RandomUserClaim);
        }
    }
}
