using CMS.DATA.Context;
using CMS.DATA.Repository.RepositoryInterface;

namespace CMS.DATA.Repository.Implementation
{
    public class CoursesRepo : ICoursesRepo
    {
        private readonly CMSDbContext _context;

        public CoursesRepo(CMSDbContext context)
        {
            _context = context;
        }
    }
}