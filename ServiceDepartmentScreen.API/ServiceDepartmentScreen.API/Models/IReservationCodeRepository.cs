using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDepartmentScreen.API.Models
{
    public interface IReservationCodeRepository
    {
        IEnumerable<ReservationCode> AllCodes { get; }
        IEnumerable<ReservationCode> ActiveCodes { get; }
        IEnumerable<ReservationCode> UpcomingCodes { get; }
        ReservationCode GetCodeById { get; }
    }
}
