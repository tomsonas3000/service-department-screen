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
    public partial class CodeOverview
    {
        [Inject]
        public IReservationCodeService ReservationCodeService { get; set; }

        public ReservationCode ReservationCode { get; set; }
        protected string CodeId = string.Empty;
        protected bool IsCancellable = false;
        protected async Task HandleSubmit()
        {
            int.TryParse(CodeId, out var codeId);
            ReservationCode = await ReservationCodeService.GetCodeById(codeId);
            if (ReservationCode != null && ReservationCode.Status == Status.Upcoming)
            {
                IsCancellable = false;
            }
        }

        protected async Task HandleCancel()
        {
            ReservationCode =
                await ReservationCodeService.UpdateStatus(ReservationCode.ReservationCodeId, Status.Cancelled);
        }
    }
}
