using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceDepartmentScreen.Shared;

namespace ServiceDepartmentScreen.API.Models
{
    public interface ISpecialistRepository
    {
        Task<Specialist> GetSpecialistById(int id);
        Task<Specialist> CheckCredentials(Specialist specialist);
    }
}
