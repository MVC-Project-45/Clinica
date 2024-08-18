namespace MVC_Final.Models
{
    public enum Gender{
        Male,
        Female 
    }
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int age { get; set; }

        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public List<Appointment>? Appointments { get; set; }
        public List<Review>? Reviews { get; set; }
        public List<PatientHistory>? PatientHistory { get; set; }
    }
}
