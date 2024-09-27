using MediaReviewSystem.Database;
using MediaReviewSystemLibrary.Models.Entities;

namespace MediaReviewSystemLibrary.DataLoader
{
    public class UserRatingDL
    {
        public static void Initialize()
        {
            LoadData();
            Console.WriteLine("Rating initialized");
        }
        private static void LoadData()
        {
            Random random = new Random();

            List<Media> allMedia = MediaDatabase.GetDb().GetMediaList();

            // Loop through each media object
            foreach (var media in allMedia)
            {
                long mediaId = media.MediaId;

                // Generate UserRating objects for UserId from "1" to "50"
                for (int i = 1; i <= 50; i++)
                {
                    long userId = i;
                    float randomScore = (float)(random.NextDouble() * 9 + 1); // Random score between 1 and 10
                    UserRating userRating = new UserRating(userId, mediaId)
                    {
                        Score = randomScore
                    };
                    MediaDatabase.GetDb().AddUserRating(userRating);
                }
            }
        }
    }
}
