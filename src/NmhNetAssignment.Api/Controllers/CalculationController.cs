using MediatR;
using Microsoft.AspNetCore.Mvc;
using NmhNetAssignment.Application.Interfaces;
using NmhNetAssignment.Application.Requests;

/// <summary>
/// Calculation Controller.
/// </summary>
[ApiController]
[Route("calculation")]
public class CalculationController : ControllerBase
{
    private readonly IMediator _mediator;

    public CalculationController(IMediator mediator)
    { 
        _mediator = mediator;
    }

    /// <summary>
    /// Calculate the value of the input
    /// </summary>
    /// <param name="key"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("{key:int}")]
    public async Task<IActionResult> Calculate([FromRoute] int key, [FromBody] CalculationRequest request)
    {
        request.Key = key;
        var result = await _mediator.Send(request);

        return Ok(result);
    }
}



