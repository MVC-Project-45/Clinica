using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Final.Models
{
    public enum Status
    {
        Pending,
        Completed,
        Cancelled
    }
    public enum Type
    {
        InitialVisit,
        FollowUp
    }
    public class Appointment
    {
        public int Id { get; set; }
        public DateOnly Date {  get; set; }
        public TimeOnly StartTime { get; set; }
        public bool IsBooked { get; set; }
        public Status Status { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }

        [ForeignKey("Doctor")]
        public int? DoctorId { get; set; }
        public Doctor? Doctor { get; set; }

        [ForeignKey("Patient")]
        public int? PateintId { get; set; }
        public Patient? Patient { get; set; }


    }
}
