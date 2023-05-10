using System.Reflection;
using DataAccessLayer.Models;
using DataAccessLayer.Models.Accounts;
using DataAccessLayer.Models.Employees;
using DataAccessLayer.Models.MessagePublisher;
using DataAccessLayer.Models.Messages;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<BasePublisherAccount> PublisherAccounts { get; set; }
    public DbSet<BaseEmployeeAccount> EmployeeAccounts { get; set; }
    public DbSet<BaseEmployee> Employees { get; set; }

    public DbSet<BaseMessagePublisher> MessagePublishers { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Report> Reports { get; set; }

    public DbSet<DeviceCountPair> DeviceInfo { get; set; }

    public DbSet<ActiveSessionModel> Sessions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.Entity<BasePublisherAccount>().HasMany(x => x.Subscribers);
    }
}