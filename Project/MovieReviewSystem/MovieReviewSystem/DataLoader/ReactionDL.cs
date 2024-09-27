using MovieReviewSystem.Library.DataManager;
using MovieReviewSystem.Models;
using System.Collections.Generic;

namespace MovieReviewSystem.DataLoader
{
    internal class ReactionDL
    {
        public static void LoadData()
        {
            ReactionDataManager reactionDataManager = new ReactionDataManager();
            List<Reaction> reactions = new List<Reaction>();

            Random random = new Random();

            List<Media> allMedia = MovieDatabase.GetDB().GetMediaList();

            // Loop through each media object
            foreach (var media in allMedia)
            {
                int mediaId = media.MediaId;

                // Generate Reaction objects for UserId from "1" to "50"
                for (int i = 1; i <= 50; i++)
                {
                    int userId = i;
                    // Randomly assign a ReactionType
                    ReactionType randomReactionType = (ReactionType)random.Next(Enum.GetValues(typeof(ReactionType)).Length);

                    // Use the new constructor to include ReactionType
                    Reaction reaction = new Reaction(userId, mediaId, randomReactionType);
                    // add reactions using data manager
                    reactionDataManager.UpdateReaction(reaction);
                }
            }
        }
    }
}

