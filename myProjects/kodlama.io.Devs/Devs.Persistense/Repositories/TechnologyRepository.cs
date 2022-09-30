using Core.Persistence.Repositories;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using Devs.Persistense.Contexts;

namespace Devs.Persistense.Repositories
{
    public class TechnologyRepository : EfRepositoryBase<Technology, BaseDbContext>, ITechnologyRepository
    {
        public TechnologyRepository(BaseDbContext context) : base(context)
        {


        }
    }
}
