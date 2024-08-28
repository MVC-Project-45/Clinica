using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Final.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string? Comment { get; set; }
        public DateTime Date {  get; set; }
        public float Rate { get; set; }
        public bool Isverified { get; set; }
        [ForeignKey("Doctor")]
        public int? DoctorId { get; set; }
        public Doctor? Doctor { get; set; }

        [ForeignKey("Patient")]
        public int? PateintId { get; set; }
        public Patient? Patient { get; set; }

    }
}
