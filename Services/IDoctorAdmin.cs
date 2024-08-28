<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 84f9ff5d8f56ef279a027ce172551f645af7c764
﻿using MVC_Final.Models;

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
<<<<<<< HEAD
=======
=======
﻿using MVC_Final.Models;

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
>>>>>>> b905b14e014d082ee4d3e4a1db7d5c994c74a9c2
>>>>>>> 84f9ff5d8f56ef279a027ce172551f645af7c764
