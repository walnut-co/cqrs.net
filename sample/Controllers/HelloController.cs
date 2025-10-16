using CQRS.Sample.Features;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : BaseController
    {
        [HttpPost]
        [Route("SayHello")]
        public async Task<IActionResult> SayHello([FromBody] SayHelloCommand command)
        {
            var result = await RequestDispatcher.Send(command);
            if (result.Succeeded)
            {
                return Ok(result.Data);
            }
            return Ok(result);
        }
    }
}
