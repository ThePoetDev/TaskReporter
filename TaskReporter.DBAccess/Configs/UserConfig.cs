using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskReporter.Class.DbConstant;
using TaskReporter.Domain.Entities;

namespace EntityFramework.Configs;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(ContextConstant.UserTableName, ContextConstant.SchemaName);
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).HasMaxLength(50);
        builder.Property(c => c.Surname).HasMaxLength(50);
    }
}