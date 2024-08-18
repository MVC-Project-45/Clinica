using MVC_Final.Models;

namespace MVC_Final.Repositories
{
    public interface IDoctorAdmin
	{
		List<Patient> GetPatientByName(string name);
        int GetPatientsCount();
		int GetApointsCount();
		double GetApointsTotalMoney();
		List<Patient> GetAllPatients();
		DateTime GetPatientDate(string name);
        void AddSchedule(WorkingTime schedule);
        void UpdateSchedule(WorkingTime schedule);
        void DeleteSchedule(int id);
        List<string> GetPatientsReviews(Doctor doctor);
        IEnumerable<WorkingTime> GetSchedule(int doctorId);
        void Save();


    }
}
