using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceDepartmentScreen.Shared;

namespace ServiceDepartmentScreen.API.Models
{
    public class SpecialistRepository : ISpecialistRepository
    {
        private readonly AppDbContext _appDbContext;
        public SpecialistRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Specialist[]> GetAllSpecialists()
        {
            IQueryable<Specialist> query = _appDbContext.Specialists;
            return await query.ToArrayAsync();
        }

        public Task<Specialist> LoginSpecialist()
        {
            throw new NotImplementedException();
        }
        
        public Task<string> LogoutSpecialist()
        {
            throw new NotImplementedException();
        }

        public async Task<Specialist> CheckCredentials(Specialist specialist)
        {
            var query = await _appDbContext.Specialists.Where(s =>
                s.Username == specialist.Username && s.Password == specialist.Password).FirstOrDefaultAsync();
            return query;
        }
    }
}
