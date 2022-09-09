using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Test.Application.Features.TaskJson.Request;

namespace Test.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class JsonTaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JsonTaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("json-values")]
        public async Task<IActionResult> UpdateJsonTasks([FromBody] string jsonValues)
        {
            var request = new AddJsonTaskRequest
            {
                JsonValues = jsonValues,
            };
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("json-values")]
        public async Task<IActionResult> GetJsonTasks([FromQuery] GetJsonTaskRequest request)
            => Ok(await _mediator.Send(request));
    }
}
