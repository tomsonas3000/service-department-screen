using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using ServiceDepartmentScreen.Shared;
using ServiceDepartmentScreen.WebApp.Services;

namespace ServiceDepartmentScreen.WebApp.Pages.Customer
{
    public partial class Generator
    {
        [Inject]
        public IReservationCodeService ReservationCodeService { get; set; }
        public ReservationCode GeneratedReservationCode { get; set; }

        protected async Task GenerateNewCode()
        {
            GeneratedReservationCode = await ReservationCodeService.GenerateNewCode();
        }
    }
}
