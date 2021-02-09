using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace ServiceDepartmentScreen.WebApp.Pages.SpecialistPages
{
    public partial class Login
    {
        [Inject] 
        public NavigationManager NavigationManager { get; set; }
        public async Task LoginUser()
        {
            NavigationManager.NavigateTo("/specialist/overview", true);
        }
    }
}
