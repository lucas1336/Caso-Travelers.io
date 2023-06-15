using Microsoft.EntityFrameworkCore;
using si730pc2u202110085.Infrastructure.Models;

namespace si730pc2u202110085.Infrastructure.Context;

public class ProjectContext : DbContext
{
    public ProjectContext()
    {
    }
    public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
    {
    }
    
    public DbSet<Plan> Plans { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
        optionsBuilder.UseMySql("Server=localhost,3306;Uid=root;Pwd=1234;Database=db_appsweb;", serverVersion);
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {

        base.OnModelCreating(builder);
        
        // Plan
        builder.Entity<Plan>().ToTable("Plans");
        builder.Entity<Plan>().HasKey(p => p.Id);
        builder.Entity<Plan>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Plan>().Property(p => p.Name).IsRequired();
        builder.Entity<Plan>().Property(p => p.maxUsers).IsRequired();
        builder.Entity<Plan>().Property(p => p.isDefault).IsRequired();

    }
}