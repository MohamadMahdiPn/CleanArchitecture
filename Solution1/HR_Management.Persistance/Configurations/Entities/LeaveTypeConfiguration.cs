using HR_Management.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR_Management.Persistance.Configurations.Entities;

public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
{
    public void Configure(EntityTypeBuilder<LeaveType> builder)
    {
        builder.HasData(
            new LeaveType
            {
                Id = 1,
                DefaultDay = 10,
                Name = "Vacation",
                CreatedBy = "mamad",
                LastModifiedBy = "mamad"
            },
            new LeaveType
            {
                Id = 2,
                DefaultDay = 12,
                Name = "Sick",
                CreatedBy = "mamad",
                LastModifiedBy = "mamad"
            });
    }
}