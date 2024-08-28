<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 84f9ff5d8f56ef279a027ce172551f645af7c764
﻿using MVC_Final.Models;

namespace MVC_Final.ViewModels
{
    public class DoctorAdminViewModel
    {
        public Doctor Doctor { get; set; }
        public List<Patient> Patients { get; set; }
        public int PatientsCount { get; set; }
        public int AppointmentsCount { get; set; }
        public decimal TotalMoney { get; set; }
        public string SearchName { get; set; }
        public IEnumerable<WorkingTime>? Schedules { get; set; }
    }
<<<<<<< HEAD
=======
=======
﻿using MVC_Final.Models;

namespace MVC_Final.ViewModels
{
    public class DoctorAdminViewModel
    {
        public Doctor Doctor { get; set; }
        public List<Patient> Patients { get; set; }
        public int PatientsCount { get; set; }
        public int AppointmentsCount { get; set; }
        public decimal TotalMoney { get; set; }
        public string SearchName { get; set; }
        public IEnumerable<WorkingTime>? Schedules { get; set; }
    }
>>>>>>> b905b14e014d082ee4d3e4a1db7d5c994c74a9c2
>>>>>>> 84f9ff5d8f56ef279a027ce172551f645af7c764
}