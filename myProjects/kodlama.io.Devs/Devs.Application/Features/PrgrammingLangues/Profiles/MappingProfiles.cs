using AutoMapper;
using Core.Persistence.Paging;
using Devs.Application.Features.PrgrammingLangues.Commands.CreateProgrammingLanguage;
using Devs.Application.Features.PrgrammingLangues.Dtos;
using Devs.Application.Features.PrgrammingLangues.Models;
using Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.PrgrammingLangues.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            
            CreateMap<ProgrammingLanguage, CreateProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, CreateProgrammingLanguageCommand>().ReverseMap();

            CreateMap<IPaginate<ProgrammingLanguage>, ProgrammingLanguageListModel>().ReverseMap();
            CreateMap<ProgrammingLanguage, ProgrammingLanguageListDto>().ReverseMap();

            CreateMap<ProgrammingLanguage, ProgrammingLanguageGetByIdDto>().ReverseMap();
        }
    }
}
