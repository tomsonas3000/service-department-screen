using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDepartmentScreen.API.Models
{
    public class ReservationCodeRepository : IReservationCodeRepository
    {
        private readonly IReservationCodeRepository _reservationCodeRepository = new ReservationCodeRepository();
        public IEnumerable<ReservationCode> AllCodes => throw new NotImplementedException();

        public IEnumerable<ReservationCode> ActiveCodes => throw new NotImplementedException();

        public IEnumerable<ReservationCode> UpcomingCodes => throw new NotImplementedException();

        public ReservationCode GetCodeById => throw new NotImplementedException();
    }
}
