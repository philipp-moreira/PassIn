using PassIn.Communication.Responses;
using PassIn.Execeptions;
using PassIn.Infrastructure.Context;

namespace PassIn.Application.UseCases.CheckIn;

public class DoAttendeeCheckInUseCase
{
    readonly PassInContext _dbContext;

    public DoAttendeeCheckInUseCase()
    {
        _dbContext = new PassInContext();
    }

    public ResponseRegisteredCheckinJson Execute(Guid attendeeId)
    {
        Validate(attendeeId);

        var entity = new PassIn.Infrastructure.Entities.CheckIn()
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            AttendeeId = attendeeId
        };

        _dbContext.CheckIns.Add(entity);
        _dbContext.SaveChanges();

        return new ResponseRegisteredCheckinJson
        {
            Id = entity.Id
        };
    }

    public void Validate(Guid attendeeId)
    {
        var attendeeExists = _dbContext.Attendees.Any(attendee => attendee.Id == attendeeId);
        if (!attendeeExists)
        {
            throw new NotFoundException("Attendee not found.");
        }

        var checkInExistis = _dbContext.CheckIns.Any(checkIn => checkIn.AttendeeId == attendeeId);
        if (checkInExistis)
        {
            throw new ConflictException("Attendee can´t do checking twice.");
        }
    }
}