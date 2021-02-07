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

        public async Task<bool> SaveChangesAsync()
        {
            return (await _appDbContext.SaveChangesAsync()) > 0;
        }

        public ReservationCode GenerateNewCode()
        {
            var query = _appDbContext.ReservationCodes.FromSqlRaw("SELECT TOP 1 -1 AS ReservationCodeId, MAX(ReservationDate) AS ReservationDate,SpecialistId, 1 AS Status FROM ReservationCodes GROUP BY SpecialistId ORDER BY ReservationDate ASC").FirstOrDefault();
            var from = query.ReservationDate;
            var newDate = from;
            if (from.DayOfWeek == DayOfWeek.Friday && 
                from.TimeOfDay >= new TimeSpan(17,45, 0))
            {
                newDate = newDate.AddDays(3);
                var ts = new TimeSpan(9, 0, 0);
                newDate = newDate.Date + ts;
            }
            else if (from.TimeOfDay >= new TimeSpan(17,45,0))
            {
                newDate = newDate.AddDays(1);
                var ts = new TimeSpan(9, 0, 0);
                newDate = newDate.Date + ts;
            }
            else
            {
                newDate = newDate.AddMinutes(15);
            }
            var code = new ReservationCode
            {
                ReservationDate = newDate,
                SpecialistId = query.SpecialistId,
                Status = Status.Upcoming
            };
            var addedEntity = _appDbContext.ReservationCodes.Add(code);
            return addedEntity.Entity;
        }

        public async Task<ReservationCode> UpdateStatus(int id, Status status)
        {
            var foundCode = await _appDbContext.ReservationCodes.FirstOrDefaultAsync(r => r.ReservationCodeId == id);
            if (foundCode == null) return null;
            foundCode.Status = status;
            await _appDbContext.SaveChangesAsync();
            return foundCode;
        }

        public async Task<bool> CheckIfActiveBySpecialist(int id)
        {
            return (await _appDbContext.ReservationCodes.CountAsync(r => r.SpecialistId == id && r.Status == Status.Active)) > 0;
        }
    }
}
