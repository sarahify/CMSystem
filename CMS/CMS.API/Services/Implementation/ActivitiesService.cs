using CMS.API.Services.ServicesInterface;
using CMS.DATA.Repository.RepositoryInterface;

namespace CMS.API.Services
{
    public class ActivitiesService : IActivitiesService
    {
        private readonly IActivitiesRepo _activitiesRepo;

        public ActivitiesService(IActivitiesRepo activitiesRepo)
        {
            _activitiesRepo = activitiesRepo;
        }
    }
}