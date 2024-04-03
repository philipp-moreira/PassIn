using PassIn.Communication.Responses;
using PassIn.Execeptions;
using PassIn.Infrastructure.Context;

namespace PassIn.Application.UseCases.CheckIn;


public class GetCheckInByIdUseCase
{
    public ResponseCheckInMadeJson Execute(Guid checkinId)
    {
        PassIn.Infrastructure.Entities.CheckIn entity;

        using (var dbContext = new PassInContext())
        {
            entity = dbContext.CheckIns.FirstOrDefault(checkIn => checkIn.Id == checkinId);
            if (entity is null)
            {
                throw new NotFoundException("CheckIn not registered yet.");
            }
        }

        return new ResponseCheckInMadeJson
        {
            Id = entity.Id,
            CreatedAt = entity.CreatedAt,
            AttendeeId = entity.AttendeeId
        };
    }
}