using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDepartmentScreen.API.Models
{
    public class SpecialistRepository : ISpecialistRepository
    {
        private readonly ISpecialistRepository _specialistRepository = new SpecialistRepository();
        public IEnumerable<Specialist> AllSpecialists => throw new NotImplementedException();
    }
}
