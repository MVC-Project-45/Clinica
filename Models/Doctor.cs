<<<<<<< HEAD
﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using GameZone.Attributes;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Final.Attributes;
using MVC_Final.Models;
using MVC_Final.Settings;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MVC_Final.Models
{
    public class Doctor 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Experince { get; set; }
        public string Qualifications {get; set;}       
        public string Img { get; set;}
        public string Address { get; set;}
        public float? TotalRate { get; set;}

        public int? Price { get; set; }
        public string? PhoneNumber { get; set; }
        public List<Patient>? Patients { get; set; }

        public List<WorkingTime>? WorkingTime { get; set;}
        public List<Appointment>? Appointments { get; set;}
        [ForeignKey("Specialization")]
        public int? SpecializationId { get; set; }
        public Specialization? Specializations { get; set;}
        public List<Review>? Reviews { get; set;}

       
    }
}
=======
﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using GameZone.Attributes;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Final.Attributes;
using MVC_Final.Models;
using MVC_Final.Settings;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MVC_Final.Models
{
    public class Doctor 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Experince { get; set; }
        public string Qualifications {get; set;}       
        public string Img { get; set;}
        public string Address { get; set;}
        public float? TotalRate { get; set;}
<<<<<<< HEAD

        public int? Price { get; set; }
        public string? PhoneNumber { get; set; }
        public List<Patient>? Patients { get; set; }

        public List<WorkingTime>? WorkingTime { get; set;}
=======
        public List<Patient>? Patients { get; set;}
        public List<WorkingTime> WorkingTime { get; set;}
>>>>>>> d576ac289627ee7cbeba60cf9920020457739937
        public List<Appointment>? Appointments { get; set;}
        [ForeignKey("Specialization")]
        public int? SpecializationId { get; set; }
        public Specialization? Specializations { get; set;}
        public List<Review>? Reviews { get; set;}

       
    }
}
>>>>>>> b905b14e014d082ee4d3e4a1db7d5c994c74a9c2
