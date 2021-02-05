using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDepartmentScreen.API.Models
{
    public interface IReservationCodeRepository
    {
        Task<ReservationCode[]> GetActiveCodes();
        Task<ReservationCode[]> GetUpcomingCodes();
        Task<ReservationCode> GetCodeById(int id);
    }
}
