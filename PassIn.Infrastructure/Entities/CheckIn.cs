using System.ComponentModel.DataAnnotations.Schema;

namespace PassIn.Infrastructure.Entities;

public class CheckIn
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid AttendeeId { get; set; }
    public Attendee Attendee { get; set; } = default!;
}