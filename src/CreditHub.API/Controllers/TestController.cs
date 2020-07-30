using System.Threading.Tasks;
using CreditHub.API.Commands.Requests;
using CreditHub.API.Controllers.Resources;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CreditHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> TestPost(
            [FromBody] TestRequestDto testRequestDto,
            [FromServices] IMediator mediator
        )
        {
            var request = new TestRequest(
                testRequestDto.Id,
                testRequestDto.Teste);

            var response = await mediator.Send(request);
            
            if (!response.Success)
                return BadRequest(response.Errors);

            return Ok(response.Result);
        }
    }
}