using MovieReviewSystem.Models;

namespace MovieReviewSystem.DataLoader
{
    internal class RatingDL
    {
        public static void LoadData()
        {
            Random random = new Random();

            // Get the list of all media from the MovieDatabase (assuming a method exists to retrieve them)
            List<Media> allMedia = MovieDatabase.GetDB().GetMediaList();

            // Loop through each media object
            foreach (var media in allMedia)
            {
                int mediaId = media.MediaId;

                // Generate UserRating objects for UserId from "1" to "50"
                for (int i = 1; i <= 50; i++)
                {
                    int userId = i;
                    float randomScore = (float)(random.NextDouble() * 9 + 1); // Random score between 1 and 10
                    UserRating userRating = new UserRating(userId, mediaId)
                    {
                        Score = randomScore
                    };
                    MovieDatabase.GetDB().AddUserRating(userRating);
                }
            }
        }
    }
}
