using Devs.Application.Features.Technologies.Commands.CreateTeknology;
using Devs.Application.Features.Technologies.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Devs.WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologyController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTechnologyCommand createTechnologyCommand)
        {
            CreateTechnologyDto result = await Mediator.Send(createTechnologyCommand);
            return Created("", result);
        }
    }
}
