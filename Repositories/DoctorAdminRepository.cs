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

		public int GetApointsCount()
		{
			return context.Appointments.Count();
		}

		// ==========need to know to implement ========= //
		public double GetApointsTotalMoney()
		{
			var totalApoints = context.Appointments.Sum(p => p.Price);
			return totalApoints;
		}
		// =================================== //
		public List<Patient> GetPatientByName(string name)
		{
			return context.Patients.Where(p => p.Name.Contains(name)).ToList();
		}

		public DateTime GetPatientDate(string name)
		{
			throw new NotImplementedException();
		}

		public int GetPatientsCount()
		{
			return context.Patients.Count();
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

        
    }
}