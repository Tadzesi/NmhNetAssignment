using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NmhNetAssignment.Application.Interfaces;
using NmhNetAssignment.Application.Requests;
using NmhNetAssignment.Application.Responses;

namespace NmhNetAssignment.Application.Handlers
{
    public class CalculationRequestHandler : IRequestHandler<CalculationRequest, CalculationResponse>
    {
        private readonly ICalculationService _calculationService;
        private readonly IRabbitMqService _rabbitMqService;
        private readonly IConfiguration _configuration;
        private readonly ILogger<CalculationRequestHandler> _logger;
        public CalculationRequestHandler(
            ICalculationService calculationService,
            IRabbitMqService rabbitMqService,
            IConfiguration configuration,
            ILogger<CalculationRequestHandler> logger)
        {
            _calculationService = calculationService;
            _rabbitMqService = rabbitMqService;
            _configuration = configuration;
            _logger = logger;

        }
        public Task<CalculationResponse> Handle(CalculationRequest request, CancellationToken cancellationToken)
        {
            var calcualtionResult = _calculationService.ProcessCalculation(request.Key, request.Input);

            _rabbitMqService.PublishMessageAsync(calcualtionResult, queueName: _configuration["RabbitMQ:QueueName"]!, cancellationToken);

            var result = new CalculationResponse
            {
                ComputedValue = calcualtionResult.ComputedValue,
                InputValue = calcualtionResult.InputValue,
                PreviousValue = calcualtionResult.PreviousValue
            };
            return Task.FromResult(result);
        }
    }
}
