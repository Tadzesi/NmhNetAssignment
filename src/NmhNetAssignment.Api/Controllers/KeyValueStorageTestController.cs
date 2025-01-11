using Microsoft.AspNetCore.Mvc;
using NmhNetAssignment.Application.Interfaces;
using NmhNetAssignment.Application.Requests;
using NmhNetAssignment.Infrastructure.Models;

namespace NmhNetAssignment.Api.Controllers
{
    /// <summary>
    /// KeyValue Storage Controller. 
    /// </summary>
    /// <remarks>
    /// Only for testing purpose. Used to store and retrieve key-value pairs.
    /// </remarks>
    [ApiController]
    [Route("test/key-value-storage")]
    public class KeyValueStorageTestController : ControllerBase
    {
        private readonly IKeyValueStorageService _keyValueStorageService;

        /// <summary>
        /// Constructor for KeyValueStorageController.
        /// </summary>
        /// <param name="keyValueStorageService"></param>
        public KeyValueStorageTestController(
            IKeyValueStorageService keyValueStorageService)
        {
            _keyValueStorageService = keyValueStorageService;
        }

        /// <summary>
        /// Store a key-value pair in the KeyValueStorageService.
        /// </summary>        
        /// <param name="request"></param>        
        /// <returns></returns>
        [HttpPost("store")]
        public IActionResult StoreValue([FromBody] StoreRequest request)
        {
            _keyValueStorageService.SetValue(request.Key, new StorageEntry());
            return Ok();
        }

        /// <summary>
        /// Retrieve a value from the KeyValueStorageService.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet("retrieve/{key:int}")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(404)]
        public IActionResult RetrieveValue(int key)
        {
            if (_keyValueStorageService.TryGetValue(key, out object? value))
            {
                return Ok(value);
            }
            return NotFound();
        }
    }
}
