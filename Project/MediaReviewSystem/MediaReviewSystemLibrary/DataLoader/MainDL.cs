namespace MediaReviewSystemLibrary.DataLoader
{
    public class MainDL
    {
        public static void Initialize()
        {
            Console.WriteLine("Initializing data...");
            MediaDL.Initialize();
            UserDL.Initialize();
            UserRatingDL.Initialize();
            ReviewDL.Initialize();
            ReactionDL.Initialize();
            TagDL.Initialize();
            TagInfoDL.Initialize();
            AdminDL.Initialize();
            Console.Clear();
        }
    }
}
