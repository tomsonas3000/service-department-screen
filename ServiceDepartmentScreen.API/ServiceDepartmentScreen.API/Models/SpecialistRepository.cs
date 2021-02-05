using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
