using Microsoft.EntityFrameworkCore;
using PassIn.Infrastructure.Entities;

namespace PassIn.Infrastructure.Context;

public class PassInContext : DbContext
{
    readonly string dbPath = "Data Source=/home/philipp/src/csharp/PassIn/databases/PassInDb.db";
    public DbSet<Event> Events { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(dbPath);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ModelCreatingToEvent(modelBuilder);
    }

    protected internal virtual void ModelCreatingToEvent(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>()
                    .Property("MaximumAttendees").HasColumnName("Maximum_Attendees");
    }
}