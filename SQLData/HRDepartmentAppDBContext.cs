using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CoreInterfaces;

namespace SQLData;
public class HRDepartmentAppDBContext : DbContext
{
    public DbSet<WorkerEntity> Workers { get; set; } = null!;
    public DbSet<DocumentEntity> Documents { get; set; } = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
           optionsBuilder.UseSqlServer($"{GetDBConnectionString()}");
        }
    }
    private string GetDBConnectionString()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(@"C:\Toadfolder\coding\с#_miniProj_2022\HumanResourcesDepartment\SQLData")
            .AddJsonFile("appsettings.json")
            .Build();
        return configuration.GetConnectionString("DefaultConnection");
    }
}
