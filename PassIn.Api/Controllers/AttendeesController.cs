using Microsoft.AspNetCore.Mvc;
using PassIn.Application.UseCases.Attendess;
using PassIn.Communication.Requests;
using PassIn.Communication.Responses;

namespace PassIn.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AttendeesController : ControllerBase
{
    [HttpGet]
    [Route("{registerId}")]
    [ProducesResponseType<ResponseRegisteredAttendeeJson>(StatusCodes.Status201Created)]
    [ProducesResponseType<ResponseErrorJson>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType<ResponseErrorJson>(StatusCodes.Status404NotFound)]
    public IActionResult Get([FromRoute] Guid registerId)
    {
        var useCase = new GetRegisterAttendeeOnEvent();
        var response = useCase.Execute(registerId);

        return Ok(response);
    }

    [HttpPost]
    [Route("{eventId}/register")]
    [ProducesResponseType<ResponseRegisteredAttendeeJson>(StatusCodes.Status201Created)]
    [ProducesResponseType<ResponseErrorJson>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType<ResponseErrorJson>(StatusCodes.Status404NotFound)]
    public IActionResult Post([FromRoute] Guid eventId, [FromBody] RequestRegisterEventJson requestRegister)
    {
        var useCase = new RegisterAttendeeOnEventUseCase();
        var response = useCase.Execute(eventId, requestRegister);

        return CreatedAtAction(nameof(Get), new { RegisterId = response.Id }, response);
    }

    [HttpGet]
    [Route("{eventId}/all")]
    [ProducesResponseType<ResponseAllAttendeesJson>(StatusCodes.Status200OK)]
    [ProducesResponseType<ResponseErrorJson>(StatusCodes.Status404NotFound)]
    public IActionResult GetAll([FromRoute] Guid eventId)
    {
        var useCase = new GetAllAttendeesByEventId();
        var response = useCase.Execute(eventId);
        return Ok(response);
    }
}