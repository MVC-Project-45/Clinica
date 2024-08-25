using Microsoft.EntityFrameworkCore;
using MVC_Final.Models;
using System.Linq;

namespace MVC_Final.Repositories
{
	public class DoctorAdminRepository : IDoctorAdmin
	{
		private readonly Context context;

		public DoctorAdminRepository(Context _context)
		{
			context = _context;
		}
        public List<Patient> GetAllPatients()
		{
			return context.Patients.ToList();
		}

		public int GetApointsCount(int id)
		{
            var doctor = GetDoctorById(id);
			return doctor.Appointments.Count();
        }
        public int GetPatientsCount(int id)
        {
            var doctor = GetDoctorById(id);
			return doctor.Patients.Count();
        }
        // ==========need to know to implement ========= //
        public double GetApointsTotalMoney(int id)
		{
            var doctor = GetDoctorById(id);
            var totalApoints = doctor.Appointments.Sum(p => p.Price);
			return totalApoints;
		}
		// =================================== //
	public Doctor GetPatientByName(string name, int id)
{
    // Assuming GetDoctorById is a method that retrieves a Doctor by their ID.
    var doctor = GetDoctorById(id);
    
    if (doctor != null)
    {
        // Filter the patients list by the provided name
        doctor.Patients = doctor.Patients
            .Where(p => p.Name.Contains(name))
            .ToList();
    }

    return doctor;
}


		public DateTime GetPatientDate(string name)
		{
			throw new NotImplementedException();
		}

	

		public List<string> GetPatientsReviews(Doctor doctor)
		{
			var doctorWithReviews = context.Doctors
				.Include(d => d.Reviews)
				.FirstOrDefault(d => d.Id == doctor.Id);

			if (doctorWithReviews == null)
				return new List<string>();

			return doctorWithReviews.Reviews.Select(r => r.Comment).ToList();
		}

        public void AddSchedule(WorkingTime schedule)
        {
			context.WorkingTime.Add(schedule);
        }

        public void DeleteSchedule(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateSchedule(WorkingTime schedule)
        {
            context.WorkingTime.Update(schedule);
			
        }

		public IEnumerable<WorkingTime> GetSchedule(int doctorId)
		{
			return context.WorkingTime
								 .Where(d => d.DoctorId == doctorId)
								 .ToList();
		}

		public void Save()
		{
			context.SaveChanges();
		}

		public Doctor GetDoctorById(int id)
		{
			return context.Doctors
				.Include(d =>d.Patients)
				.Include(d => d.WorkingTime)
				.Include(d=>d.Appointments)
				.Include(d=>d.Specializations)
				.Include(d=>d.Reviews)
				.FirstOrDefault(d => d.Id==id);
		}

        public List<Patient> GetPatientByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}