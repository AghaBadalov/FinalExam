using Medicio.DAL;
using Medicio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Medicio.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
       

        public IActionResult Index()
        {
            List<Doctor> doctors=_dbContext.Doctors.Include(x=>x.Profession).Where(x=>x.IsDeleted==false).ToList();
            return View(doctors);
        }

        
    }
}