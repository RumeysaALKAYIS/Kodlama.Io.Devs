using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devs.Application.Features.Technologies.Dtos;
using Devs.Domain.Entities;
using Devs.Application.Features.Technologies.Commands.CreateTeknology;

namespace Devs.Application.Features.Technologies.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateTechnologyDto, Technology>().ReverseMap();
            CreateMap<CreateTechnologyCommand, Technology>().ReverseMap();

            CreateMap<Technology, CreateTechnologyDto>().ForMember(c => c.ProgrammingLanguageName, opt => opt.MapFrom(c => c.ProgrammingLanguage.Name)).ReverseMap();
        }
    }
}
