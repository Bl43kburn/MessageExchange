using DataAccessLayer.Models.Accounts;
using DataAccessLayer.Models.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.ModelConfigurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<BaseEmployee>
{
    public void Configure(EntityTypeBuilder<BaseEmployee> builder)
    {
        builder.HasDiscriminator<string>("employee_type")
            .HasValue<Employee>("employee")
            .HasValue<Master>("master");
    }
}