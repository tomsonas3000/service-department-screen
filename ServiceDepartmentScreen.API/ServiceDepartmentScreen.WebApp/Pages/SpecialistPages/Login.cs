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
    public partial class Login
    {
        [Inject] 
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public ISpecialistService SpecialistService { get; set; }

        public LoginModel LoginModel = new LoginModel();
        public async Task LoginUser()
        {
            Specialist loginSpecialist = new Specialist();
            loginSpecialist.Username = LoginModel.Username;
            loginSpecialist.Password = LoginModel.Password;
            await SpecialistService.Login(loginSpecialist);
            //NavigationManager.NavigateTo("/specialist/overview", false);
        }
    }
}
