using CMS.API.Services.ServicesInterface;
using CMS.DATA.Repository.RepositoryInterface;

namespace CMS.API.Services
{
    public class CoursesService : ICoursesService
    {
        private readonly ICoursesRepo _coursesRepo;

        public CoursesService(ICoursesRepo coursesRepo)
        {
            _coursesRepo = coursesRepo;
        }
    }
}