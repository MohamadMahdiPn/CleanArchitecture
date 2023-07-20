using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR_Management.Identity.Configurations;

public class UserRoleConfiguration:IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData(
            new IdentityUserRole<string>
            {
                UserId = "6c806f69-8b1d-4617-9a79-ccf8db4dba6a",
                RoleId = "155c10df-b1ee-4e13-b6e0-9a9f01b1580a"
            });
    }
}