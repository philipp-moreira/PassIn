namespace PassIn.Infrastructure.Entities;

public class Attendee
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Guid EventId { get; set; }
    public DateTime CreatedAt { get; set; }
    public CheckIn? CheckIn { get; set; }
}