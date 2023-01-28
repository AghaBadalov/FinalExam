using Medicio.DAL;
using Medicio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;

namespace Medicio.Areas.manage.Controllers
{
    [Area("manage")]

    public class ProfessionController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ProfessionController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List<Profession> professions=_dbContext.Professions.ToList();
            return View(professions);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Profession profession)
        {
            if(!ModelState.IsValid) return View();
            _dbContext.Professions.Add(profession);
            _dbContext.SaveChanges();
            return RedirectToAction("index");
        }
        
        public IActionResult Update(int id)
        {
            Profession profession = _dbContext.Professions.Find(id);
            if (profession is null) return NotFound();
            return View(profession);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Profession profession)
        {
            Profession exstprofession=_dbContext.Professions.FirstOrDefault(x=>x.Id== profession.Id);
            if(exstprofession is null) return NotFound();
            if(!ModelState.IsValid) return View(exstprofession);
            exstprofession.Name = profession.Name;
            _dbContext.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            Profession profession = _dbContext.Professions.Find(id);
            if (profession is null) return NotFound();
            _dbContext.Professions.Remove(profession);
            _dbContext.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
