using MovieReviewSystem.Library.DataHandler;
using MovieReviewSystem.Models;

namespace MovieReviewSystem.Library.DataManager
{
    internal class ReviewDataManager
    {
        private ReviewDataHandler _reviewDataHandler;

        public ReviewDataManager()
        {
            _reviewDataHandler = new ReviewDataHandler();
        }

        internal void AddReview(Review review)
        {
            _reviewDataHandler.StoreReview(review);
        }

        public List<Review> GetByMediaId(int mediaId)
        {
            return _reviewDataHandler.GetAll().FindAll(review => review.MediaId == mediaId).ToList();
        }

        public Review GetById(int id)
        {
            return _reviewDataHandler.GetById(id);
        }

    }
}