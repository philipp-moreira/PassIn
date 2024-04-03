using Microsoft.EntityFrameworkCore;
using PassIn.Infrastructure.Entities;

namespace PassIn.Infrastructure.Context;

public class PassInContext : DbContext
{
    #region Fields/Constants
    readonly string dbPath = "Data Source=/home/philipp/src/csharp/PassIn/databases/PassInDb.db";
    #endregion

    #region Properties
    public DbSet<Event> Events { get; set; }
    public DbSet<Attendee> Attendees { get; set; }
    public DbSet<CheckIn> CheckIns { get; set; }

    #endregion

    #region Methods
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(dbPath);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ModelCreatingToEvent(modelBuilder);
        ModelCreatingToAttendee(modelBuilder);
        ModelCreatingToCheckIn(modelBuilder);
    }

    protected internal virtual void ModelCreatingToEvent(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>()
                    .Property("MaximumAttendees").HasColumnName("Maximum_Attendees");
    }

    protected internal virtual void ModelCreatingToAttendee(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendee>(build =>
        {
            build.Property("EventId").HasColumnName("Event_Id");
            build.Property("CreatedAt").HasColumnName("Created_At");
        });
    }

    protected internal virtual void ModelCreatingToCheckIn(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CheckIn>(build =>
        {
            build.Property("AttendeeId").HasColumnName("Attendee_Id");
            build.Property("CreatedAt").HasColumnName("Created_At");
        });
    }

    #endregion
}