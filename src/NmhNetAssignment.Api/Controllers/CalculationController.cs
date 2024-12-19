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
    private readonly IRabbitMqService _rabbitMqService;
    private readonly IKeyValueStorageService _keyValueStorageService;
    private readonly IConfiguration _configuration;
    private readonly ICalculationService _calculationService;
    private readonly IMediator _mediator;

    public CalculationController(
        IRabbitMqService rabbitMqService,
        IKeyValueStorageService keyValueStorageService,
        IConfiguration configuration,
        ICalculationService calculationService,
        IMediator mediator)
    {
        _rabbitMqService = rabbitMqService;
        _keyValueStorageService = keyValueStorageService;
        _configuration = configuration;
        _calculationService = calculationService;
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



