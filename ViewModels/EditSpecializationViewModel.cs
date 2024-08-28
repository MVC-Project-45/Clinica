using MVC_Final.Models;

namespace MVC_Final.ViewModels
{
    public class EditSpecializationViewModel : CreateSpecializationFormViewModel
    {
        public int ID { get; set; }
        public string? CurrentCover { get; set; }
        public List<Doctor?> doctors {get;set;}
    }
}
