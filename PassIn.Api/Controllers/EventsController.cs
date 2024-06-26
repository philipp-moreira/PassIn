using Microsoft.AspNetCore.Mvc;
using PassIn.Application.UseCases.Events;
using PassIn.Communication.Requests;
using PassIn.Communication.Responses;

namespace PassIn.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    [HttpGet]
    [Route("{eventId}")]
    [ProducesResponseType<ResponseEventJson>(StatusCodes.Status200OK)]
    [ProducesResponseType<ResponseErrorJson>(StatusCodes.Status404NotFound)]
    public IActionResult Get([FromRoute] Guid eventId)
    {
        var eventUseCase = new GetEventByIdUseCase();
        var response = eventUseCase.Execute(eventId);

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType<ResponseRegisteredEventJson>(StatusCodes.Status201Created)]
    [ProducesResponseType<ResponseErrorJson>(StatusCodes.Status400BadRequest)]
    public IActionResult Post([FromBody] RequestEventJson requestEvent)
    {

        var eventUseCase = new RegisterEventUseCase();
        var response = eventUseCase.Execute(requestEvent);

        return CreatedAtAction(nameof(Get), new { EventId = response.Id }, response);
    }
}