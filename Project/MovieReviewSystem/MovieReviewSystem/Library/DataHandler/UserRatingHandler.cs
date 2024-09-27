using MovieReviewSystem.Library.DataHandler.Contracts;
using MovieReviewSystem.Models;

namespace MovieReviewSystem.Library.DataHandler
{
    internal class UserRatingHandler : IUserRatingHandler
    {
        private MovieDatabase _database;

        public UserRatingHandler()
        {
            _database = MovieDatabase.GetDB(); // Singleton in-memory database
        }

        // Retrieve all user ratings
        public List<UserRating> GetRatingList()
        {
            return _database.GetUserRatingList();
        }

        // Get ratings filtered by media ID
        public List<UserRating> GetRatingsByMediaId(int mediaId)
        {
            return _database.GetUserRatingList().Where(rating => rating.MediaId == mediaId).ToList();
        }

        // Add a new user rating
        public void AddRating(UserRating rating)
        {
            _database.AddUserRating(rating);
        }

        // Remove a user rating
        public void RemoveRating(UserRating rating)
        {
            _database.RemoveUserRating(rating);
        }

        // Get a specific user's rating for a specific media
        public UserRating GetRating(int userId, int mediaId)
        {
            return _database.GetUserRatingList().FirstOrDefault(r => r.UserId == userId && r.MediaId == mediaId);
        }
    }
}
