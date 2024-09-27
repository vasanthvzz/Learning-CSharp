using MovieReviewSystem.Models;

namespace MovieReviewSystem.Library.DataHandler.Contracts
{
    internal interface IReviewDataHandler
    {
        public Review GetById(int reviewId);
        public List<Review> GetAll();
        public void StoreReview(Review review);
        public void Delete(Review review);
    }
}
