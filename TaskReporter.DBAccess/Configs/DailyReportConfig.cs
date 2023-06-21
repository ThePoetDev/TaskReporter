using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskReporter.Domain.Entities;

namespace EntityFramework.Configs;

public class DailyReportConfig : IEntityTypeConfiguration<DailyReport>
{
    public void Configure(EntityTypeBuilder<DailyReport> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Context).HasMaxLength(500);
        builder.Property(c => c.Subject).HasMaxLength(100);
        builder.Property(c => c.Title).HasMaxLength(100);
    }
}