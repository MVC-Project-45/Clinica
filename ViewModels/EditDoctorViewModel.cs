<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Mvc;
using MVC_Final.Models;

namespace MVC_Final.ViewModels
{
    public class EditDoctorViewModel : CreateDoctorsFormViewModel
    {
        public int ID { get; set; }
        public string? CurrentCover { get; set; }
        public List<Specialization> specializations { get; set; }
    }
}
=======
﻿using Microsoft.AspNetCore.Mvc;
using MVC_Final.Models;

namespace MVC_Final.ViewModels
{
    public class EditDoctorViewModel : CreateDoctorsFormViewModel
    {
        public int ID { get; set; }
        public string? CurrentCover { get; set; }
        public List<Specialization> specializations { get; set; }
    }
}
>>>>>>> b905b14e014d082ee4d3e4a1db7d5c994c74a9c2
