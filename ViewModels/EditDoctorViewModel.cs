using Microsoft.AspNetCore.Mvc;
using MVC_Final.Models;

namespace MVC_Final.ViewModels
{
    public class EditDoctorViewModel : CreateDoctorsFormViewModel
    {
        public int ID { get; set; }
        public string? CurrentCover { get; set; }
        public List<Specialization> specializations { get; set; }
    }
}
