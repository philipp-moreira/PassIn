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
        var registerAttendeeUseCase = new GetRegisterAttendeeOnEvent();
        var response = registerAttendeeUseCase.Execute(registerId);

        return Ok(response);
    }

    [HttpPost]
    [Route("{eventId}/register")]
    [ProducesResponseType<ResponseRegisteredAttendeeJson>(StatusCodes.Status201Created)]
    [ProducesResponseType<ResponseErrorJson>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType<ResponseErrorJson>(StatusCodes.Status404NotFound)]
    public IActionResult Post([FromRoute] Guid eventId, [FromBody] RequestRegisterEventJson requestRegister)
    {
        var registerAttendeeUseCase = new RegisterAttendeeOnEventUseCase();
        var response = registerAttendeeUseCase.Execute(eventId, requestRegister);

        return CreatedAtAction(nameof(Get), new { RegisterId = response.Id }, response);
    }
}