using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceDepartmentScreen.Shared
{
    public class Specialist
    {
        public int SpecialistId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
