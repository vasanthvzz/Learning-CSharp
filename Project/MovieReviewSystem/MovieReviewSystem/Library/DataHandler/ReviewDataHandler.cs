using MovieReviewSystem.Library.DataHandler.Contracts;
using MovieReviewSystem.Models;


namespace MovieReviewSystem.Library.DataHandler
{
    internal class ReviewDataHandler : IReviewDataHandler
    {
        private MovieDatabase _database;

        public ReviewDataHandler()
        {
            _database = MovieDatabase.GetDB();
        }

        public Review GetById(int reviewId)
        {
            var query = _database.GetReviewList().Where(review => review.ReviewId == reviewId);
            return query.FirstOrDefault();
        }

        public List<Review> GetAll()
        {
            return _database.GetReviewList();
        }

        public void StoreReview(Review review)
        {
            _database.AddReview(review);
        }

        public void Delete(Review review)
        {
            _database.RemoveReview(review);
        }
    }
}
