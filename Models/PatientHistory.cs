using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Final.Models
{
    public class PatientHistory
    {
        public int Id { get; set; }
        public string Description { get; set; }

        [ForeignKey("Patient")]
        public int? PateintId { get; set; }
        public Patient? Patient { get; set; }
    }
}
