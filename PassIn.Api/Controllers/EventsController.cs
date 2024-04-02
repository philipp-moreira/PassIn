using Microsoft.AspNetCore.Mvc;
using PassIn.Application.UseCases.Events;
using PassIn.Communication.Requests;
using PassIn.Communication.Responses;
using PassIn.Execeptions;

namespace PassIn.Api.Controllers;

[Controller]
[Route("api/[controller]")]
public class EventsController : Controller
{
    [HttpGet("eventId")]
    [ProducesResponseType<ResponseEventJson>(StatusCodes.Status200OK)]
    [ProducesResponseType<ResponseErrorJson>(StatusCodes.Status404NotFound)]
    public IActionResult Get([FromQuery] Guid eventId)
    {
        try
        {
            var eventUseCase = new GetEventByIdUseCase();
            var response = eventUseCase.Execute(eventId);

            return Ok(response);
        }
        catch (PassInExeception ex)
        {
            return NotFound(new ResponseErrorJson(ex.Message));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost]
    [ProducesResponseType<ResponseEventJson>(StatusCodes.Status201Created)]
    [ProducesResponseType<ResponseErrorJson>(StatusCodes.Status400BadRequest)]
    public IActionResult Post([FromBody] RequestEventJson requestEvent)
    {
        try
        {
            var eventUseCase = new RegisterEventUseCase();
            var response = eventUseCase.Execute(requestEvent);

            return CreatedAtAction(nameof(Get), new { Id = response.Id }, response);
        }
        catch (PassInExeception ex)
        {
            return NotFound(new ResponseErrorJson(ex.Message));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}