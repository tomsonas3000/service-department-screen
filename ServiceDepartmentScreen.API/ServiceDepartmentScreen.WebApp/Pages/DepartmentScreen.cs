using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using ServiceDepartmentScreen.Shared;
using ServiceDepartmentScreen.WebApp.Services;

namespace ServiceDepartmentScreen.WebApp.Pages
{
    public partial class DepartmentScreen
    {
        [Inject]
        public IReservationCodeService ReservationCodeService { get; set; }
        public IEnumerable<ReservationCode> ActiveCodes { get; set; }
        public IEnumerable<ReservationCode> UpcomingCodes { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ActiveCodes = (await ReservationCodeService.GetActiveCodes()).ToList();
            UpcomingCodes = (await ReservationCodeService.GetUpcomingCodes()).ToList();
            UpdateData();
        }

        protected void  UpdateData()
        {
            var timer = new Timer(new TimerCallback(async _ =>
            {
                 ActiveCodes = (await ReservationCodeService.GetActiveCodes()).ToList();
                 UpcomingCodes = (await ReservationCodeService.GetUpcomingCodes()).ToList();
                 StateHasChanged();
            }), null, 5000, 5000);
        }
    }
}
