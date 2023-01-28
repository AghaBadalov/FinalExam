using Medicio.DAL;
using Medicio.Helpers;
using Medicio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Medicio.Areas.manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin,Admin")]

    public class DoctorController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IWebHostEnvironment _env;

        public DoctorController(AppDbContext dbContext,IWebHostEnvironment env)
        {
            _dbContext = dbContext;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Doctor> doctors = _dbContext.Doctors.Include(x=>x.Profession).ToList();
            return View(doctors);
        }
        public IActionResult Create()
        {
            ViewBag.Professions = _dbContext.Professions;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Doctor doctor)
        {
            ViewBag.Professions = _dbContext.Professions;
            if(!ModelState.IsValid) return View(doctor);
            if (doctor.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Can't be null");
                return View(doctor);
            }
            if(doctor.ImageFile.Length > 2097152)
            {
                ModelState.AddModelError("ImageFile", " you can upload Only 2mb or less files");
                return View(doctor);
            }
            if (doctor.ImageFile.ContentType!="image/png"&& doctor.ImageFile.ContentType != "image/jpeg")
            {
                ModelState.AddModelError("ImageFile", " Only png,jpeg or jpg type");
                return View(doctor);
            }
            doctor.ImageUrl = doctor.ImageFile.SaveFile(_env.WebRootPath, "uploads/doctors");
            doctor.IsDeleted = false;
            _dbContext.Doctors.Add(doctor);
            _dbContext.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Update(int id)
        {
            ViewBag.Professions = _dbContext.Professions;

            Doctor doctor = _dbContext.Doctors.FirstOrDefault(x=>x.Id==id);
            if(doctor == null) return NotFound();
            return View(doctor);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Doctor doctor)
        {
            ViewBag.Professions = _dbContext.Professions;

            Doctor exstdoctor =_dbContext.Doctors.FirstOrDefault(x=>x.Id==doctor.Id);
            if (exstdoctor is null) return NotFound();
            if (!ModelState.IsValid) return View(doctor);
            if(doctor.ImageFile != null)
            {
                if (doctor.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", " you can upload Only 2mb or less files");
                    return View(doctor);
                }
                if (doctor.ImageFile.ContentType != "image/png" && doctor.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", " Only png,jpeg or jpg type");
                    return View(doctor);
                }
                string path = Path.Combine(_env.WebRootPath, "uploads/doctors", exstdoctor.ImageUrl);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                exstdoctor.ImageUrl = doctor.ImageFile.SaveFile(_env.WebRootPath, "uploads/doctors");
            }
            exstdoctor.ProfessionId = doctor.ProfessionId;
            exstdoctor.Name = doctor.Name;
            exstdoctor.TTUrl = doctor.TTUrl;
            exstdoctor.IGUrl = doctor.IGUrl;
            exstdoctor.FBUrl = doctor.FBUrl;
            exstdoctor.LNUrl = doctor.LNUrl;

            _dbContext.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            Doctor doctor = _dbContext.Doctors.FirstOrDefault(x => x.Id == id);
            if (doctor == null) return NotFound();
            string path = Path.Combine(_env.WebRootPath, "uploads/doctors", doctor.ImageUrl);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            _dbContext.Doctors.Remove(doctor);
            _dbContext.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
