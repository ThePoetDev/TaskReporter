using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskReporter.Domain.Entities;

namespace EntityFramework.Configs;

public class MonthlyReportConfig : IEntityTypeConfiguration<MonthlyReport>
{
    public void Configure(EntityTypeBuilder<MonthlyReport> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Context).HasMaxLength(500);
        builder.Property(c => c.Subject).HasMaxLength(100);
        builder.Property(c => c.Title).HasMaxLength(100);
        builder.Property(c => c.MonthName).HasMaxLength(50);
    }
}