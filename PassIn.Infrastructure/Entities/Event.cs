using System.ComponentModel.DataAnnotations.Schema;

namespace PassIn.Infrastructure.Entities;

public class Event
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public int MaximumAttendees { get; set; }
    [ForeignKey("Event_id")]
    public List<Attendee> Attendees { get; set; } = [];
}