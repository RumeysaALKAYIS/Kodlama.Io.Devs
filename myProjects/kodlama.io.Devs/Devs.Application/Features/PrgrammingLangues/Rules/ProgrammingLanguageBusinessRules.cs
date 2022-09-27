using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Devs.Application.Features.PrgrammingLangues.Constants.ProgrammingLanguageBusineseRules;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.PrgrammingLangues.Rules
{
    public class ProgrammingLanguageBusinessRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task ProgrammingLanguageCanNotBeDuplicatedWhenInsertes(string name)
        {
            IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(p => p.Name == name);

            if (result.Items.Any())
            {
                throw new BusinessException(ProgrammingLanguageBusineseRulesConstants.CanNotBeDecupling);
            }
        }

        public async Task ProgrammingLanguageCanNotBeNull(string name)
        {
           
            if (name==null)
            {
                throw new BusinessException(ProgrammingLanguageBusineseRulesConstants.CanNotBeNull);
            }
        }
    }
}
