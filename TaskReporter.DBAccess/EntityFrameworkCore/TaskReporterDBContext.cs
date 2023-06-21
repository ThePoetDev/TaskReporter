using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TaskReporter.Domain.Entities;

namespace EntityFramework.EntityFrameworkCore;

public class TaskReporterDBContext : DbContext
{
    public TaskReporterDBContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    
    
}