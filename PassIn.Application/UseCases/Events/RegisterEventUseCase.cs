using PassIn.Communication.Requests;
using PassIn.Communication.Responses;
using PassIn.Execeptions;
using PassIn.Infrastructure.Context;
using PassIn.Infrastructure.Entities;

namespace PassIn.Application.UseCases.Events;

public class RegisterEventUseCase
{
    public ResponseRegisteredEventJson Execute(RequestEventJson requestEvent)
    {
        Validate(requestEvent);

        var entity = new Event()
        {
            Title = requestEvent.Title,
            Details = requestEvent.Details,
            MaximumAttendees = requestEvent.MaximumAttendees,
            Slug = requestEvent.Title.Replace(' ', '-')
        };

        using (var context = new PassInContext())
        {
            context.Events.Add(entity);
            context.SaveChanges();
        }

        return new ResponseRegisteredEventJson()
        {
            Id = entity.Id
        };
    }

    private void Validate(RequestEventJson requestEvent)
    {
        if (requestEvent.MaximumAttendees <= 0)
        {
            throw new ErrorOnValidationException("Maximum attendees should be grather than 0 (zero).");
        }

        if (string.IsNullOrWhiteSpace(requestEvent.Title))
        {
            throw new ErrorOnValidationException("Title not should be empty/null.");
        }

        if (string.IsNullOrWhiteSpace(requestEvent.Details))
        {
            throw new ErrorOnValidationException("Details not should be empty/null.");
        }
    }
}