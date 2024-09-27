using MovieReviewSystem.Models;

namespace MovieReviewSystem.DataLoader
{
    internal class ActorInfoDL
    {
        public static void LoadData()
        {
            var db = MovieDatabase.GetDB();
            List<ActorInfo> actorInfos = new List<ActorInfo>();

            //80 actors and 36 media entries
            for (int actorId = 1; actorId <= 80; actorId++)
            {
                // Randomly assign 3 to 5 mediaId to each actor
                int mediaCount = new Random().Next(3, 6); // Random number of media associations
                List<int> selectedMediaIds = new List<int>();

                while (selectedMediaIds.Count < mediaCount)
                {
                    // Randomly choose a mediaId between 1 and 36
                    int mediaId = new Random().Next(1, 37);

                    // Ensure no duplicate mediaIds for the same actor
                    if (!selectedMediaIds.Contains(mediaId))
                    {
                        selectedMediaIds.Add(mediaId);
                        actorInfos.Add(new ActorInfo(actorId, mediaId));
                    }
                }
            }

            db.GetActorInfoList().AddRange(actorInfos);
        }
    }
}
