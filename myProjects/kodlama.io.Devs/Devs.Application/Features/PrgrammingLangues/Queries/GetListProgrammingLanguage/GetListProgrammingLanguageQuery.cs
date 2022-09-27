using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Devs.Application.Features.PrgrammingLangues.Models;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.PrgrammingLangues.Queries.GetListProgrammingLanguage
{
    public class GetListProgrammingLanguageQuery:IRequest<ProgrammingLanguageListModel>
    {

        public PageRequest PageRequest { get; set; }

        public class GetListProgrammingLanguageHandler : IRequestHandler<GetListProgrammingLanguageQuery,ProgrammingLanguageListModel>
        {
            private IProgrammingLanguageRepository _repository;
            private IMapper _mapper;

            public GetListProgrammingLanguageHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
            {
                _repository = programmingLanguageRepository;
                _mapper = mapper;
            }

            public async Task<ProgrammingLanguageListModel> Handle(GetListProgrammingLanguageQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgrammingLanguage> programmingLanguage =
                    await _repository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                ProgrammingLanguageListModel mapped=_mapper.Map<ProgrammingLanguageListModel>(programmingLanguage);

                return mapped;


            }
        }
    }
}
