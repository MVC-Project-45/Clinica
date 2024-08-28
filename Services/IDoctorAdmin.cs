using MVC_Final.Models;

namespace MVC_Final.Services
{
    public interface IDoctorAdmin
    {
        Doctor GetDoctorWithFilteredPatients(string name, int doctorId);

        int GetApointsCount(int id);
        double GetApointsTotalMoney(int id);
        int GetPatientsCount(int id);
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
