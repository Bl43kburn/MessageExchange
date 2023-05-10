using DataAccessLayer.Models.Accounts;
using DataAccessLayer.Models.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.ModelConfigurations;

public class EmployeeAccountConfiguration : IEntityTypeConfiguration<BaseEmployeeAccount>
{
    public void Configure(EntityTypeBuilder<BaseEmployeeAccount> builder)
    {
        builder.HasDiscriminator<string>("employee_account_type")
            .HasValue<EmployeeAccount>("employee_account")
            .HasValue<MasterAccount>("master_account");
    }
}