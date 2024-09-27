using MovieReviewSystem.Library.DataManager;
using MovieReviewSystem.Models;
using MovieReviewSystem.Models.Wrapper;

static class Writer
{
    public static void WriteTitle(string title)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("**********************************\n");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\t{title}");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n**********************************");
        Console.ResetColor();
        Console.WriteLine();  // Add spacing after the title
    }

    public static bool InvalidChoice()
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You have entered an invalid option!");
            Console.ResetColor();
            Console.WriteLine("Do you want to try again? (y/n)");
            string choice = Console.ReadLine()?.Trim().ToLower();

            if (choice == "y")
            {
                return true;
            }
            else if (choice == "n")
            {
                return false;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                Console.ResetColor();
            }
        }
    }

    public static void WriteMedia(Media media)
    {
        MediaDetails mediaDetails = MediaWrapper.WrapToMediaDetail(media);
        Console.WriteLine("\n");

        UserRatingDataManager userRatingDataManager = new UserRatingDataManager();
        mediaDetails.Rating = userRatingDataManager.GetMovieRating(media.MediaId);
        int ratingCount = userRatingDataManager.GetUsersRatedCount(media.MediaId);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{media.MediaId}  {media.Name} \t\t {(mediaDetails.Rating == 0 ? "No reviews" : mediaDetails.Rating + "/10")}");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(mediaDetails.Tags.Count > 0 ? $"   ({string.Join(" | ", mediaDetails.Tags)} ) \n" : "");
        Console.WriteLine(media.Description);
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Cast : " + string.Join(", ", mediaDetails.Actors));
        Console.WriteLine();
        Console.ResetColor();
        Console.WriteLine("\n");
    }

    public static void WriteReview(Review review, string userName)
    {
        Console.WriteLine("\n");
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine(review.ReviewId);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"{userName}  {review.Datetime.ToShortDateString()}");
        Console.ResetColor();
        Console.WriteLine(review.Description);
        Console.WriteLine("\n");
    }

    public static void WriteMenu(string s)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"------\t\t {s}\t\t------");
        Console.ResetColor();
        Console.WriteLine(); // Add spacing after menu
    }

    internal static void WriteComment(Comment comment)
    {
        UserDataManager userDataManager = new UserDataManager();
        string userName = userDataManager.GetUserName(comment.UserId);
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine($"\t\t{comment.CommentId}-{userName}\t\t{comment.Datetime.ToShortDateString()}");
        Console.ResetColor();
        Console.WriteLine("\t\t" + comment.Description);
        Console.WriteLine();
    }

    internal static void PrintAllTag()
    {
        TagDataManager tagDataManager = new TagDataManager();
        Console.ForegroundColor = ConsoleColor.Cyan;
        foreach (Tag tag in tagDataManager.GetAll())
        {
            Console.WriteLine(tag.TagId + " - " + tag.TagName);
        }
        Console.ResetColor();
        Console.WriteLine();  // Add spacing after tag list
    }

    internal static void PrintAllActors()
    {
        ActorDataManager actorDataManager = new ActorDataManager();
        List<Actor> sortedActors = actorDataManager.GetAll()
                                   .OrderBy(actor => actor.ActorName)
                                   .ToList();

        Console.ForegroundColor = ConsoleColor.Cyan;
        foreach (Actor actor in sortedActors)
        {
            Console.WriteLine(actor.ActorId + " - " + actor.ActorName);
        }
        Console.ResetColor();
        Console.WriteLine();  // Add spacing after actor list
    }

    internal static void ViewEnd()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\n Enter a key to continue...");
        Console.ResetColor();
        Console.ReadKey();
        Console.WriteLine();  // Add spacing after the key press
    }
}
