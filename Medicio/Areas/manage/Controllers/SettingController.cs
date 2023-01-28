using Medicio.DAL;
using Medicio.Helpers;
using Medicio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medicio.Areas.manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles ="SuperAdmin,Admin")]
    public class SettingController : Controller
    {
        private readonly AppDbContext _dbContext;

        public SettingController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index(int page=1)
        {
            var query = _dbContext.SettingUsers.AsQueryable();
            PaginatedList<Setting> settings = PaginatedList<Setting>.Create(query, 4, page);

            return View(settings);
        }
        public IActionResult Update(int id)
        {
            Setting setting = _dbContext.SettingUsers.FirstOrDefault(x => x.Id == id);
            if(setting is null) return NotFound();

            return View(setting);
        }
        [HttpPost]
        public IActionResult Update(Setting setting)
        {
            Setting exstsetting = _dbContext.SettingUsers.FirstOrDefault(x => x.Id == setting.Id);
            if(exstsetting is null) return NotFound();
            if (!ModelState.IsValid) return View(setting);
            exstsetting.Value=setting.Value;
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
