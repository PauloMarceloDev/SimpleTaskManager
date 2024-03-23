using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SimpleTaskManager.Infrastructure.Configurations;

internal sealed class TaskConfiguration : IEntityTypeConfiguration<Domain.Tasks.Task>
{
    public void Configure(EntityTypeBuilder<Domain.Tasks.Task> builder)
    {
        builder.ToTable("Tasks");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Title).HasMaxLength(255).IsRequired();

        builder.Property(e => e.Description).HasMaxLength(2048).IsRequired();

        builder.Property(e => e.Priority).IsRequired();

        builder.Property(e => e.DeadlineOnUtc).IsRequired();

        builder.Property(e => e.Status).IsRequired();
    }
}
