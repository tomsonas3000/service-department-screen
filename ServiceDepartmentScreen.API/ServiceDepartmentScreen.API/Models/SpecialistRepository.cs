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
        public IEnumerable<Specialist> AllSpecialists => _appDbContext.Specialists;
    }
}
