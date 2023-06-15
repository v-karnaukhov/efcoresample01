using IssueWithAnyAll.Configs;
using IssueWithAnyAll.Entities;
using Microsoft.EntityFrameworkCore;

namespace IssueWithAnyAll;

public class DataContext : DbContext
{
    private static string connectionString;


    public DataContext()
        : base()
    {
    }

    private string ConnectionString { get; set; }

    public DataContext(string connectionString) : base()
    {
        this.ConnectionString = connectionString;
    }

    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(this.ConnectionString);

        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<RequestType> RequestTypes { get; set; }

    public DbSet<RequestStatus> RequestStatuses { get; set; }

    public DbSet<Request> Requests { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {

        builder.HasDefaultSchema("dbo");

        builder.ApplyConfiguration(new RequestConfig());
        builder.ApplyConfiguration(new RequestTypeConfig());
        builder.ApplyConfiguration(new RequestStatusConfig());
    }
}
