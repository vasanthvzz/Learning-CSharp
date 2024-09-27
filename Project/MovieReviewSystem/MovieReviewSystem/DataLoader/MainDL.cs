namespace MovieReviewSystem.DataLoader
{
    internal class MainDL
    {
        public static void Initialize()
        {
            MediaDL.LoadData();
            UserDL.LoadData();
            ReviewDL.LoadData();
            ReactionDL.LoadData();
            RatingDL.LoadData();
            ActorDL.LoadData();
            ActorInfoDL.LoadData();
            TagDL.LoadData();
            TagInfoDL.LoadData();
        }
    }
}
