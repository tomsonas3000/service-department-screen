using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceDepartmentScreen.API.Models
{
    public class ReservationCode
    {
        public int ReservationCodeId { get; set; }
        public DateTime ReservationDate { get; set; }
        public bool HasBegun { get; set; }
        public bool IsCancelled { get; set; }
        public bool HasEnded { get; set; }
        public int SpecialistId { get; set; }
        public Specialist Specialist { get; set; }
    }
}
