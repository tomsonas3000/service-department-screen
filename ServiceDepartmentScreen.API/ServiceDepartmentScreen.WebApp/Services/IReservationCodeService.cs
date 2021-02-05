using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceDepartmentScreen.Shared;

namespace ServiceDepartmentScreen.WebApp.Services
{
    public interface IReservationCodeService
    {
        Task<IEnumerable<ReservationCode>> GetActiveCodes();
        Task<IEnumerable<ReservationCode>> GetUpcomingCodes();
        Task<ReservationCode> GetCodeById(int id);
        Task<IEnumerable<ReservationCode>> GetCodesBySpecialistId(int specialistId);
    }
}
