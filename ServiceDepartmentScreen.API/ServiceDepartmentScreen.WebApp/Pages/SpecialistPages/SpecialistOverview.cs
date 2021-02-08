using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using ServiceDepartmentScreen.Shared;
using ServiceDepartmentScreen.WebApp.Services;

namespace ServiceDepartmentScreen.WebApp.Pages.SpecialistPages
{
    public partial class SpecialistOverview
    {
        [Inject]
        public ISpecialistService SpecialistService { get; set; }
        [Inject]
        public IReservationCodeService ReservationCodeService { get; set; }
        public Specialist Specialist { get; set; }   
        public IEnumerable<ReservationCode> ReservationCodes { get; set; }

    }
}
