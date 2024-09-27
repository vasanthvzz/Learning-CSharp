using MovieReviewSystem.Library.DataHandler;
using MovieReviewSystem.Models;
using System.Linq;

internal class UserRatingDataManager
{
    private MediaDataHandler _mediaDataHandler;
    private UserRatingHandler _userRatingHandler;

    public UserRatingDataManager(MediaDataHandler mediaDataHandler)
    {
        _mediaDataHandler = mediaDataHandler;
        _userRatingHandler = new UserRatingHandler();
    }

    public UserRatingDataManager()
    {
        _mediaDataHandler = new MediaDataHandler();
        _userRatingHandler = new UserRatingHandler();
    }

    public float GetMovieRating(int mediaId)
    {
        var ratingList = _userRatingHandler.GetRatingsByMediaId(mediaId);
        if (ratingList.Count == 0)
            return 0;

        var totalRatingSum = ratingList.Sum(m => m.Score);
        return (float)Math.Round(totalRatingSum / ratingList.Count, 2);
    }

    public int GetUsersRatedCount(int mediaId)
    {
        var ratingList = _userRatingHandler.GetRatingsByMediaId(mediaId);
        return ratingList.Count;
    }

    public void UpdateRating(UserRating updatedRating)
    {
        var existingRating = _userRatingHandler.GetRating(updatedRating.MediaId, updatedRating.UserId);
        if (existingRating != null)
        {
            existingRating.Score = updatedRating.Score;
        }
        else
        {
            _userRatingHandler.AddRating(updatedRating);
        }
    }

    public UserRating GetRating(int userId, int mediaId)
    {
        return _userRatingHandler.GetRating(userId, mediaId);
    }
}
