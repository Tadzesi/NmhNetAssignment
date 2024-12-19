using Microsoft.AspNetCore.Mvc;
using NmhNetAssignment.Application.Interfaces;
using NmhNetAssignment.Application.Requests;

namespace NmhNetAssignment.Api.Controllers
{
    /// <summary>
    /// Rabbit MQ Controller. 
    /// </summary>
    /// <remarks>
    /// Only for testing purpose. Used to publish messages to RabbitMQ.
    /// </remarks>
    [ApiController]
    [Route("test/rabbit-mq")]
    public class RabbitMqTestController : ControllerBase
    {
        private readonly IRabbitMqService _rabbitMqService;

        /// <summary>
        /// Constructor for RabbitMqController.
        /// </summary>
        /// <param name="rabbitMqService"></param>
        public RabbitMqTestController(IRabbitMqService rabbitMqService)
        {
            _rabbitMqService = rabbitMqService;
        }

        /// <summary>
        /// Publish a message to a RabbitMQ queue.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("publish")]
        public async Task<IActionResult> PublishMessage([FromBody] PublishRequest request)
        {
            await _rabbitMqService.PublishMessageAsync(request.Message, request.QueueName);
            return Ok();
        }
    }
}
