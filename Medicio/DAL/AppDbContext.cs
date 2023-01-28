using Medicio.Models;
using Microsoft.EntityFrameworkCore;

namespace Medicio.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
    }
}
