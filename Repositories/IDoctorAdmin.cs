using MVC_Final.Models;

namespace MVC_Final.Repositories
{
    public interface IDoctorAdmin
	{
        Doctor GetPatientByName(string name, int id);
        int GetPatientsCount(int id);

        int GetApointsCount(int id);
		double GetApointsTotalMoney(int id);
		List<Patient> GetAllPatients();
        Doctor GetDoctorById(int id);
		DateTime GetPatientDate(string name);
        void AddSchedule(WorkingTime schedule);
        void UpdateSchedule(WorkingTime schedule);
        void DeleteSchedule(int id);
        List<string> GetPatientsReviews(Doctor doctor);
        IEnumerable<WorkingTime> GetSchedule(int doctorId);
        void Save();


    }
}
