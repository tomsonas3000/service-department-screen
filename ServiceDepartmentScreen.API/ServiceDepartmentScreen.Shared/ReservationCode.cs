using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceDepartmentScreen.Shared
{
    public class ReservationCode
    {
        public int ReservationCodeId { get; set; }
        public DateTime ReservationDate { get; set; }
        public Status Status { get; set; }
        public int SpecialistId { get; set; }
        public Specialist Specialist { get; set; }
    }
}
