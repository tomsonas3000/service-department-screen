using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDepartmentScreen.API.Models
{
    public interface ISpecialistRepository
    {
        IEnumerable<Specialist> AllSpecialists { get; }
    }
}
