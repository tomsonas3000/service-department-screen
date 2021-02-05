using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceDepartmentScreen.Shared;

namespace ServiceDepartmentScreen.API.Models
{
    public class ReservationCodeRepository : IReservationCodeRepository
    {
        private readonly AppDbContext _appDbContext;
        public ReservationCodeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ReservationCode[]> GetActiveCodes()
        {
            var query = _appDbContext.ReservationCodes.Where(r => r.Status == Status.Active);
            return await query.ToArrayAsync();
        }

        public async Task<ReservationCode> GetCodeById(int id)
        {
            var query = _appDbContext.ReservationCodes.Where(r => r.ReservationCodeId == id).Include(r => r.Specialist);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<ReservationCode[]> GetUpcomingCodes()
        {
            var query = _appDbContext.ReservationCodes.Where(r => r.Status == Status.Upcoming).Take(5);
            return await query.ToArrayAsync();
        }

        public async Task<ReservationCode[]> GetCodesBySpecialistId(int id)
        {
            var query = _appDbContext.ReservationCodes.Where(r => r.SpecialistId == id);
            return await query.ToArrayAsync();
        }
    }
}
