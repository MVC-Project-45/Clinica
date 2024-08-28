<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MVC_Final.Models
{
    public enum Gender{
        Male,
        Female

        
    }
    public class Patient 
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(0, 150, ErrorMessage = "Age must be between 0 and 150")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"^[0-9]{11}$", ErrorMessage = "Phone Number must be 11 digits")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        public List<Appointment>? Appointments { get; set; }
        public List<Review>? Reviews { get; set; }
        public List<PatientHistory>? PatientHistory { get; set; }
    }
}
=======
﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MVC_Final.Models
{
    public enum Gender{
        Male,
        Female 
    }
    public class Patient 
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(0, 150, ErrorMessage = "Age must be between 0 and 150")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"^[0-9]{11}$", ErrorMessage = "Phone Number must be 11 digits")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        public List<Appointment>? Appointments { get; set; }
        public List<Review>? Reviews { get; set; }
        public List<PatientHistory>? PatientHistory { get; set; }
    }
}
>>>>>>> b905b14e014d082ee4d3e4a1db7d5c994c74a9c2
