using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDepartmentScreen.API.Models
{
    public class ReservationCodeRepository : IReservationCodeRepository
    {
        private readonly AppDbContext _appDbContext;
        public ReservationCodeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<ReservationCode> AllCodes
        {
            get
            {
                return _appDbContext.ReservationCodes;
            }
        }

        public IEnumerable<ReservationCode> ActiveCodes
        {
            get
            {
                return _appDbContext.ReservationCodes.Where(c => c.HasBegun);
            }
        }

        public IEnumerable<ReservationCode> UpcomingCodes => throw new NotImplementedException();

        public ReservationCode GetCodeById => throw new NotImplementedException();
    }
}
