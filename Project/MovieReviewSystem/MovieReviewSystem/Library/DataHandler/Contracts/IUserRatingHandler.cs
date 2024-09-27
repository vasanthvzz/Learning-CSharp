using MovieReviewSystem.Models;

namespace MovieReviewSystem.Library.DataHandler.Contracts
{
    internal interface IUserRatingHandler
    {
        public List<UserRating> GetRatingList();
        public List<UserRating> GetRatingsByMediaId(int mediaId);
        public void AddRating(UserRating rating);
        public void RemoveRating(UserRating rating);
        public UserRating GetRating(int userId, int mediaId);
    }
}
