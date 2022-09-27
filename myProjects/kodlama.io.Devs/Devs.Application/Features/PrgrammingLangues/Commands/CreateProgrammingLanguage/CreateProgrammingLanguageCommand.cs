using AutoMapper;
using Devs.Application.Features.PrgrammingLangues.Dtos;
using Devs.Application.Features.PrgrammingLangues.Rules;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;

namespace Devs.Application.Features.PrgrammingLangues.Commands.CreateProgrammingLanguage
{
    public class CreateProgrammingLanguageCommand:IRequest<CreateProgrammingLanguageDto>
    {
        public string Name { get; set; }

        public class CreateProgrammingLanguageCommandHandler : IRequestHandler<CreateProgrammingLanguageCommand, CreateProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _repository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _rules;

            public CreateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _repository = programmingLanguageRepository;
                _mapper = mapper;
                _rules = programmingLanguageBusinessRules;


            }

            public async Task<CreateProgrammingLanguageDto> Handle(CreateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _rules.ProgrammingLanguageCanNotBeDuplicatedWhenInsertes(request.Name);

                await  _rules.ProgrammingLanguageCanNotBeNull(request.Name);

               ProgrammingLanguage mappenprogrammingLanguage = _mapper.Map<ProgrammingLanguage>(request);
               ProgrammingLanguage createprogrammingLanguage=await _repository.AddAsync(mappenprogrammingLanguage);

                CreateProgrammingLanguageDto createProgrammingLanguageDto=_mapper.Map<CreateProgrammingLanguageDto>(createprogrammingLanguage);

                return createProgrammingLanguageDto;
            }
        }
    }
}
