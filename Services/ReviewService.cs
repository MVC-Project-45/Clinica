namespace MVC_Final.Models
{
    public class ReviewService:IReviewService
    {
        Context context;
        public ReviewService(Context context)
        {
            this.context = context;
        }
        public List<Review> GetByDoctor(int doctorId)
        {

            return context.Reviews.Where(d => d.DoctorId == doctorId).ToList();
        }

        public void Add(Review review) { 
            
        context.Add(review);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
