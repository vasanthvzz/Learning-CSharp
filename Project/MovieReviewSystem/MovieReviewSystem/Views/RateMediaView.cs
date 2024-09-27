
using MovieReviewSystem.Models;
using MovieReviewSystem.Views.Utilities;

namespace MovieReviewSystem.Views
{

    internal class RateMediaView : IView
    {
        private readonly UserRatingDataManager _ratingDataManager;
        private readonly MediaDataManager _mediaDataManager;

        public RateMediaView()
        {
            _ratingDataManager = new UserRatingDataManager();
            _mediaDataManager = new MediaDataManager();
        }
        public void Initialize()
        {
            Console.Clear();
            Console.WriteLine("------\t\tRate the movie\t\t----------");
            GetMovieDetail();
        }

        public void GetMovieDetail()
        {
            Console.WriteLine("Enter movie id :");
            int movieId = Parser.ParseToInt();
            Media media = _mediaDataManager.GetMovieById(movieId);
            if (media == null)
            {
                Console.WriteLine("Movie not found ");
            }
            else
            {
                Writer.WriteMedia(media);
                EnterMovieRating(media);
            }
        }

        private void EnterMovieRating(Media media)
        {
            UserRating rating = _ratingDataManager.GetRating(SessionHandler.GetUserId(), media.MediaId);
            if (rating == null)
            {
                rating = new UserRating(SessionHandler.GetUserId(), media.MediaId);
                Console.WriteLine("Rating has been created");
            }
            else
            {
                Console.WriteLine("You have already rated this movies as " + rating.Score + " /10");
            }
            bool validInput = false;
            do
            {
                Console.WriteLine("Enter Rating for the movie : (1 to 10)");
                validInput = float.TryParse(Console.ReadLine(), out float score) && score <= 10 && score >= 1;
                if (!validInput)
                {
                    Console.WriteLine("Please enter a proper rating : (1 to 10)");
                }
                else
                {
                    rating.Score = score;
                }
            } while (!validInput);
            _ratingDataManager.UpdateRating(rating);
            Console.WriteLine("Rating have been added successfully");
            Console.ReadKey();
        }
    }
}
