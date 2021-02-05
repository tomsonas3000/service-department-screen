using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceDepartmentScreen.Shared;

namespace ServiceDepartmentScreen.API.Models
{
    public interface IReservationCodeRepository
    {
        Task<ReservationCode[]> GetActiveCodes();
        Task<ReservationCode[]> GetUpcomingCodes();
        Task<ReservationCode> GetCodeById(int id);
        Task<ReservationCode[]> GetCodesBySpecialistId(int id);
        void GetNewCode();
    }
}
