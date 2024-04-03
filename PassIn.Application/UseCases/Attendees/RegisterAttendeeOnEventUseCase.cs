using System.Data.Common;
using System.Net.Mail;
using Microsoft.EntityFrameworkCore;
using PassIn.Communication.Requests;
using PassIn.Communication.Responses;
using PassIn.Execeptions;
using PassIn.Infrastructure.Context;
using PassIn.Infrastructure.Entities;

namespace PassIn.Application.UseCases.Attendess;

public class RegisterAttendeeOnEventUseCase
{
    PassInContext _dbContext;

    public RegisterAttendeeOnEventUseCase()
    {
        _dbContext = new PassInContext();
    }

    public ResponseRegisteredAttendeeJson Execute(Guid eventId, RequestRegisterEventJson requestRegister)
    {
        Validate(eventId, requestRegister);

        var attendeeEntity = new Attendee()
        {
            Id = Guid.NewGuid(),
            Name = requestRegister.Name,
            Email = requestRegister.Email,
            EventId = eventId,
            CreatedAt = DateTime.UtcNow
        };

        _dbContext.Attendees.Add(attendeeEntity);
        _dbContext.SaveChanges();

        return new ResponseRegisteredAttendeeJson
        {
            Id = attendeeEntity.Id
        };
    }

    void Validate(Guid eventId, RequestRegisterEventJson requestRegister)
    {

        if (string.IsNullOrWhiteSpace(requestRegister.Name))
        {
            throw new ErrorOnValidationException($"{nameof(requestRegister.Name)} should not be empty/null.");
        }

        if (!EmailIsvalid(requestRegister.Email))
        {
            throw new ErrorOnValidationException($"{nameof(requestRegister.Email)} invalid.");
        }

        var eventEntity = _dbContext.Events.FirstOrDefault(ev => ev.Id == eventId);
        if (eventEntity is null)
        {
            throw new NotFoundException("Event not exists.");
        }

        var registerToAttendeeExists = _dbContext.Attendees
                                            .Any(attendee =>
                                                attendee.Email.Equals(requestRegister.Email)
                                                &&
                                                attendee.EventId == eventId);
        if (registerToAttendeeExists)
        {
            throw new ConflictException("Attendee already registered to event.");
        }

        var registersToEvent = _dbContext.Attendees.Count(ev => ev.EventId == eventId );
        if (registersToEvent == eventEntity.MaximumAttendees)
        {
            throw new ErrorOnValidationException("Maximum event capacity reached.");
        }
    }

    static bool EmailIsvalid(string email)
    {
        try
        {
            new MailAddress(email);
            return true;
        }
        catch
        {
            return false;
        }
    }
}