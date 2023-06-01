
using CMS.API.Services.ServicesInterface;
using CMS.DATA.Repository.RepositoryInterface;

namespace CMS.API.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepo _usersRepo;

        public UsersService(IUsersRepo usersRepo)
        {
            _usersRepo = usersRepo;
        }
    }
}