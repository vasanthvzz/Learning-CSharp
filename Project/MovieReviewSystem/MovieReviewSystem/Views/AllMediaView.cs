using MediaReviewSystem.Models;
using MovieReviewSystem.DataLoader;
using MovieReviewSystem.Views.Utilities;

namespace MovieReviewSystem.Views
{
    internal class AllMediaView : IView
    {
        private MediaDataManager _mediaDataManager;
        private UserRatingDataManager _userRatingDataManager;
        public AllMediaView()
        {
            _mediaDataManager = new MediaDataManager();
            _userRatingDataManager = new UserRatingDataManager();
        }

        public void Initialize()
        {
            Console.Clear();
            List<Media> mediaList = _mediaDataManager.GetAllMedia();
            foreach (Media media in mediaList)
            {
                Writer.WriteMedia(media);
            }
            SelectMovieMenu();
            Writer.ViewEnd();
        }

        private void SelectMovieMenu()
        {
            Console.WriteLine("Do you want to select any movie ? ('y' or 'n' ");
            string choice = Console.ReadLine();
            if (choice == "y")
            {
                Console.WriteLine();
            }
        }

        private void GetMovieId()
        {
            Console.WriteLine("Enter movie id : ");
            int movieId = Parser.ParseToInt();
            Media media = _mediaDataManager.GetMovieById(movieId);
            if (media == null)
            {
                Console.WriteLine("Movie not found ! ");
            }
            else
            {
                IView manageMediaView = new ManageMediaView(media);
                manageMediaView.Initialize();
            }
        }
    }
}
