using CMS.DATA.Context;
using CMS.DATA.Entities;
using CMS.MVC.Services.ServicesInterface;
using Microsoft.AspNetCore.Identity;

namespace CMS.MVC.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly CMSDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signinManager;
     
        public UserService(CMSDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signinManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signinManager = signinManager;
        }
    }
}
