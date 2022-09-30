using AutoMapper;
using Devs.Application.Features.Technologies.Dtos;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.Technologies.Commands.CreateTeknology
{
    public class CreateTechnologyCommand:IRequest<CreateTechnologyDto>
    {
        public string Name { get    ; set; }
        public string ProgrammingLanguage { get; set; }

        public class CreateTeknologyCommandHandler : IRequestHandler<CreateTechnologyCommand, CreateTechnologyDto>
        {

            private readonly IMapper _mapper;
            private readonly ITechnologyRepository _technologyRepository;

            public CreateTeknologyCommandHandler(IMapper mapper, ITechnologyRepository technologyRepository)
            {
                _mapper = mapper;
                _technologyRepository = technologyRepository;
            }

            public async Task<CreateTechnologyDto> Handle(CreateTechnologyCommand request, CancellationToken cancellationToken)
            {
                Technology mappedtechnology =  _mapper.Map<Technology>(request);
                Technology cretedtechnology=await _technologyRepository.AddAsync(mappedtechnology);

                CreateTechnologyDto createTechnologyDto= _mapper.Map<CreateTechnologyDto>(cretedtechnology);

                return createTechnologyDto;
            }
        }
    }
}
