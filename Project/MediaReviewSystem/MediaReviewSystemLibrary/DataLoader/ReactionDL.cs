using MediaReviewSystem.Database;
using MediaReviewSystemLibrary.Models.Entities;

namespace MediaReviewSystemLibrary.DataLoader
{
    public class ReactionDL
    {
        public static void Initialize()
        {
            LoadData();
        }
        private static void LoadData()
        {
            List<Reaction> reactions = new List<Reaction>();

            Random random = new Random();

            List<Media> allMedia = MediaDatabase.GetDb().GetMediaList();

            // Loop through each media object
            foreach (var media in allMedia)
            {
                long mediaId = media.MediaId;

                // Generate Reaction objects for UserId from "1" to "50"
                for (int i = 1; i <= 50; i++)
                {
                    long userId = i;
                    // Randomly assign a ReactionType
                    ReactionType randomReactionType = (ReactionType)random.Next(Enum.GetValues(typeof(ReactionType)).Length);

                    // Use the new constructor to include ReactionType
                    Reaction reaction = new Reaction(userId, mediaId, randomReactionType);
                    // add reactions using data manager
                    MediaDatabase.GetDb().AddReaction(reaction);
                }
            }
        }
    }
}
