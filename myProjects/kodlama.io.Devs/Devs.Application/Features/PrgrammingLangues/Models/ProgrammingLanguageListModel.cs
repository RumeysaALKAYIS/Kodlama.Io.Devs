using Core.Persistence.Paging;
using Devs.Application.Features.PrgrammingLangues.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.PrgrammingLangues.Models
{
    public class ProgrammingLanguageListModel:BasePageableModel
    {
        public IList<ProgrammingLanguageListDto> items { get; set; }
    }
}
