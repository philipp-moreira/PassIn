using PassIn.Communication.Responses;
using PassIn.Execeptions;
using PassIn.Infrastructure.Context;
using PassIn.Infrastructure.Entities;

namespace PassIn.Application.UseCases.Attendess;

public class GetRegisterAttendeeOnEvent
{
    public ResponseAttendeeJson Execute(Guid registerId)
    {
        Attendee registerEntity;
        using (var dbContext = new PassInContext())
        {
            registerEntity = dbContext.Attendees.FirstOrDefault(reg => reg.Id == registerId);
            if (registerEntity is null)
            {
                throw new NotFoundException("Register attendee on event not found.");
            }
        }

        return new ResponseAttendeeJson
        {
            Id = registerEntity.Id,
            Name = registerEntity.Name,
            Email = registerEntity.Email,
            CreatedAt = registerEntity.CreatedAt,
        };
    }
}