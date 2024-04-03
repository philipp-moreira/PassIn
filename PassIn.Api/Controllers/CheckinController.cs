using Microsoft.AspNetCore.Mvc;
using PassIn.Application.UseCases.CheckIn;
using PassIn.Communication.Responses;

namespace PassIn.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CheckinController : ControllerBase
{
    [HttpGet]
    [Route("{checkinId}")]
    [ProducesResponseType<ResponseCheckInMadeJson>(StatusCodes.Status200OK)]
    [ProducesResponseType<ResponseErrorJson>(StatusCodes.Status404NotFound)]
    public IActionResult Get([FromRoute] Guid checkinId)
    {
        var useCase = new GetCheckInByIdUseCase();
        var response = useCase.Execute(checkinId);
        return Ok(response);
    }

    [HttpPost]
    [Route("{attendeeId}")]
    [ProducesResponseType<ResponseRegisteredCheckinJson>(StatusCodes.Status201Created)]
    [ProducesResponseType<ResponseErrorJson>(StatusCodes.Status404NotFound)]
    [ProducesResponseType<ResponseErrorJson>(StatusCodes.Status409Conflict)]
    public IActionResult Post([FromRoute] Guid attendeeId)
    {
        var useCase = new DoAttendeeCheckInUseCase();
        var response = useCase.Execute(attendeeId);
        return CreatedAtAction(nameof(Get), new { CheckinId = response.Id }, response);
    }
}