using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Final.Models
{
    public class WorkingTime
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }

        public int Duration { get; set; }
        [ForeignKey("Doctor")]
        public int? DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        public DayOfWeek DayOfWeek { get; set; }

    }
}
