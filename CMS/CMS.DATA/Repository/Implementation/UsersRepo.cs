using CMS.DATA.Context;
using CMS.DATA.Entities;
using CMS.DATA.Repository.RepositoryInterface;
using Microsoft.AspNetCore.Identity;

namespace CMS.DATA.Repository.Implementation
{
    public class UsersRepo : IUsersRepo
    {
        private readonly CMSDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersRepo(CMSDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
    }
}