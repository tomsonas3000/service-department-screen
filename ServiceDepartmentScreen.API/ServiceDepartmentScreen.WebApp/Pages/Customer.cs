﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using ServiceDepartmentScreen.WebApp.Services;

namespace ServiceDepartmentScreen.WebApp.Pages
{
    public partial class Customer
    {
        [Inject]
        public IReservationCodeService ReservationCodeService { get; set; }


        
    }
}
