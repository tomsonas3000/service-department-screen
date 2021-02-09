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

        public async Task<Specialist> GetSpecialistById(int id)
        {
            var query = _appDbContext.Specialists.Where(r => r.SpecialistId == id);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Specialist> CheckCredentials(Specialist specialist)
        {
            var query = await _appDbContext.Specialists.Where(s =>
                s.Username == specialist.Username && s.Password == specialist.Password).FirstOrDefaultAsync();
            return query;
        }
    }
}
