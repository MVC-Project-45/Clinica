using System.ComponentModel.DataAnnotations;
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
