using Medicio.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Medicio.DAL
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}
