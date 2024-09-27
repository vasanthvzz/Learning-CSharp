using MovieReviewSystem.Library.DataManager;
using MovieReviewSystem.Models;
using MovieReviewSystem.Views.Utilities;

namespace MovieReviewSystem.Views
{
    internal class ReviewMediaView : IView
    {
        private readonly MediaDataManager _mediaDataManager;
        private readonly ReviewDataManager _reviewDataManager;

        public ReviewMediaView()
        {
            _mediaDataManager = new MediaDataManager();
            _reviewDataManager = new ReviewDataManager();
        }
        public void Initialize()
        {
            Console.Clear();
            Writer.WriteMenu("Review Movie : ");
            GetMovieDetail();
        }

        private void GetMovieDetail()
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
                EnterReviewDetails(media);
            }
        }

        private void EnterReviewDetails(Media media)
        {
            Console.WriteLine("Enter the review for the movie : ");
            string description = Console.ReadLine();
            Review review = new Review(SessionHandler.GetUserId(), media.MediaId, description);
            _reviewDataManager.AddReview(review);
            Console.WriteLine("Review has been added successfully");
            Console.ReadKey();
        }


    }
}
