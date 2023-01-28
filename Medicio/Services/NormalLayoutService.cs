using Medicio.DAL;
using Medicio.Models;
using Microsoft.EntityFrameworkCore;

namespace Medicio.Services
{
    public class NormalLayoutService
    {
        private readonly AppDbContext _dbContext;

        public NormalLayoutService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Setting>> GetSettings()
        {
            return await _dbContext.SettingUsers.ToListAsync();
        }
    }
}
