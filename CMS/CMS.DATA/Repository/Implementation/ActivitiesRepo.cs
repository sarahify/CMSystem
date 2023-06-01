using CMS.DATA.Context;
using CMS.DATA.Repository.RepositoryInterface;

namespace CMS.DATA.Repository.Implementation
{
    public class ActivitiesRepo : IActivitiesRepo
    {
        private readonly CMSDbContext _context;

        public ActivitiesRepo(CMSDbContext context)
        {
            _context = context;
        }
    }
}