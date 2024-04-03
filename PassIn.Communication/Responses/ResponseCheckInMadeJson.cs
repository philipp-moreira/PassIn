namespace PassIn.Communication.Responses;

public class ResponseCheckInMadeJson
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid AttendeeId { get; set; }
}