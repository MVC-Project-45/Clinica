<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 84f9ff5d8f56ef279a027ce172551f645af7c764
﻿using GameZone.Attributes;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Final.Attributes;
using MVC_Final.Models;
using MVC_Final.Settings;
using System.ComponentModel.DataAnnotations;


namespace MVC_Final.ViewModels
{
    public class CreateSpecializationFormViewModel
    {
        
        public int Id { get; set; }

        public int spIdForUpdate { get; set; } = default!;
        public string Name { get; set; } = string.Empty;

        public List<int>? SelectedDoctors { get; set; } = default!;
        public IEnumerable<SelectListItem>? Doctors { get; set; } = Enumerable.Empty<SelectListItem>();

        public string Cover { get; set; } = default!;
        
    }
}
<<<<<<< HEAD
=======
=======
﻿using GameZone.Attributes;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Final.Attributes;
using MVC_Final.Models;
using MVC_Final.Settings;
using System.ComponentModel.DataAnnotations;


namespace MVC_Final.ViewModels
{
    public class CreateSpecializationFormViewModel
    {
        
        public int Id { get; set; }

        public int spIdForUpdate { get; set; } = default!;
        public string Name { get; set; } = string.Empty;

        public List<int>? SelectedDoctors { get; set; } = default!;
        public IEnumerable<SelectListItem>? Doctors { get; set; } = Enumerable.Empty<SelectListItem>();

        public string Cover { get; set; } = default!;
        
    }
}
>>>>>>> b905b14e014d082ee4d3e4a1db7d5c994c74a9c2
>>>>>>> 84f9ff5d8f56ef279a027ce172551f645af7c764
