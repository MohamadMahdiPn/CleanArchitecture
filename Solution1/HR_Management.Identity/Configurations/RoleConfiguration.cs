using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR_Management.Identity.Configurations;

public class RoleConfiguration:IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Id = "6ac05123-848a-4aed-9ccb-5489afd050ef",
                Name = "Employee",
                NormalizedName = "EMPLOYEE",
            }
            , new IdentityRole
            {
                Id = "155c10df-b1ee-4e13-b6e0-9a9f01b1580a",
                Name = "administrator",
                NormalizedName = "ADMINISTRATOR",
            }
        );
    }
}