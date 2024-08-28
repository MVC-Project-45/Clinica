<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 84f9ff5d8f56ef279a027ce172551f645af7c764
﻿using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace MVC_Final.Models
{
    public class Specialization
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //[MaxLength(2500)]
        //public string Description { get; set; } = string.Empty;

        [MaxLength(500)]
        public string  Cover { get; set; }
        public ICollection<Doctor>? Doctors { get; set; }=new List<Doctor>();

    }
}
=======
﻿using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace MVC_Final.Models
{
    public class Specialization
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //[MaxLength(2500)]
        //public string Description { get; set; } = string.Empty;

        [MaxLength(500)]
        public string  Cover { get; set; }
        public ICollection<Doctor>? Doctors { get; set; }=new List<Doctor>();

    }
}
>>>>>>> b905b14e014d082ee4d3e4a1db7d5c994c74a9c2
