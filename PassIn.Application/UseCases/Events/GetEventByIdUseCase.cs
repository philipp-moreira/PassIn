using Microsoft.EntityFrameworkCore;
using PassIn.Communication.Responses;
using PassIn.Execeptions;
using PassIn.Infrastructure.Context;

namespace PassIn.Application.UseCases.Events;

public class GetEventByIdUseCase
{
    public ResponseEventJson Execute(Guid id)
    {
        try
        {
            using (var context = new PassInContext())
            {
                var entity = context.Events.Include(ev => ev.Attendees).FirstOrDefault(ev => ev.Id == id);
                if (entity is null)
                {
                    throw new NotFoundException($"Don't exists event to id '{id}'.");
                }

                return new ResponseEventJson()
                {
                    Id = entity.Id,
                    Title = entity.Title,
                    Details = entity.Details,
                    MaximumAttendees = entity.MaximumAttendees,
                    AttendeesAmount = entity.Attendees.ToList().Count
                };
            };
        }
        catch (Exception)
        {
            throw;
        }
    }
}