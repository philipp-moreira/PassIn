using Microsoft.EntityFrameworkCore;
using PassIn.Communication.Responses;
using PassIn.Execeptions;
using PassIn.Infrastructure.Context;

namespace PassIn.Application.UseCases.Attendess;

public class GetAllAttendeesByEventId
{
    readonly PassInContext _dbContext;

    public GetAllAttendeesByEventId()
    {
        _dbContext = new PassInContext();
    }

    public ResponseAllAttendeesJson Execute(Guid eventId)
    {
        var @event = _dbContext.Events
                                    .Include(ev => ev.Attendees)
                                    .ThenInclude(atendee => atendee.CheckIn)
                                    .FirstOrDefault(ev => ev.Id == eventId);
        if (@event is null)
        {
            throw new NotFoundException("Event not found by this Id.");
        }

        return new ResponseAllAttendeesJson
        {
            Attendees = @event.Attendees.Select(attendee => new ResponseAttendeeJson
            {
                Id = attendee.Id,
                Name = attendee.Name,
                Email = attendee.Email,
                CreatedAt = attendee.CreatedAt,
                CheckedInAt = attendee.CheckIn?.CreatedAt
            }).ToList()
        };

    }
}