using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using ServiceDepartmentScreen.Shared;
using ServiceDepartmentScreen.WebApp.Services;

namespace ServiceDepartmentScreen.WebApp.Pages.SpecialistPages
{
    public partial class SpecialistOverview
    {
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject]
        public ISpecialistService SpecialistService { get; set; }
        [Inject]
        public IReservationCodeService ReservationCodeService { get; set; }
        public Specialist Specialist { get; set; }   
        public IEnumerable<ReservationCode> ReservationCodes { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            if (authState.User.Identity.IsAuthenticated)
            {
                var id = authState.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier);
                Specialist = await SpecialistService.GetSpecialistById(Convert.ToInt32(id?.Value));
            }
            else
            {
                Specialist = new Specialist();
            }
        }

    }
}
