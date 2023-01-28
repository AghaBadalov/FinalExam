using Medicio.Models;
using Microsoft.AspNetCore.Identity;

namespace Medicio.Areas.manage.Services
{
    public class LayoutService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public LayoutService(UserManager<AppUser> userManager,IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }
        public async Task<AppUser> GetUser()
        {
            string name =  _contextAccessor.HttpContext.User.Identity.Name;


            return await _userManager.FindByNameAsync(name);


        }
    }
}
