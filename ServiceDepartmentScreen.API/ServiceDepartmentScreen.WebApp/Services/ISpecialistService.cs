using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceDepartmentScreen.Shared;

namespace ServiceDepartmentScreen.WebApp.Services
{
    public interface ISpecialistService
    {
        Task Login(Specialist specialist);
    }
}
