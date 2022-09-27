using Core.Application.Requests;
using Devs.Application.Features.PrgrammingLangues.Commands.CreateProgrammingLanguage;
using Devs.Application.Features.PrgrammingLangues.Dtos;
using Devs.Application.Features.PrgrammingLangues.Models;
using Devs.Application.Features.PrgrammingLangues.Queries.GetByIdProgrammingLanguage;
using Devs.Application.Features.PrgrammingLangues.Queries.GetListProgrammingLanguage;
using Microsoft.AspNetCore.Mvc;

namespace Devs.WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguageController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand createProgrammingLanguageCommand)
        {
            CreateProgrammingLanguageDto result = await Mediator.Send(createProgrammingLanguageCommand);


            return Created("", result);
        }

        [HttpGet]

        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgrammingLanguageQuery getListProgrammingLanguageQuery =new () { PageRequest = pageRequest };
            ProgrammingLanguageListModel result = await Mediator.Send(getListProgrammingLanguageQuery);

            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgrammingLanguageQuery getByIdProgrammingLanguageQuery)
        {
            ProgrammingLanguageGetByIdDto languageGetByIdDto = await Mediator.Send(getByIdProgrammingLanguageQuery);
            return Ok(languageGetByIdDto);
        }

    }
}
