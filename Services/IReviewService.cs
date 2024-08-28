namespace MVC_Final.Models
{
    public interface IReviewService
    {
        public List<Review> GetByDoctor(int doctorId);
        public void Add(Review review);
        public void Save();
    }
}
