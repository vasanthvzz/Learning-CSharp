
using MovieReviewSystem.Library.DataManager;
using MovieReviewSystem.Models;
using MovieReviewSystem.Views.Utilities;
using System.Numerics;
using System.Runtime.Intrinsics.Arm;

namespace MovieReviewSystem.Views
{
    internal class PersonalMediaView : IView
    {
        private readonly PersonalMediaDataManager _personalMediaDataManager;
        private readonly MediaDataManager _mediaDataManager;

        public PersonalMediaView()
        {
            _personalMediaDataManager = new PersonalMediaDataManager();
            _mediaDataManager = new MediaDataManager();
        }

        public void Initialize()
        {
            Console.Clear();
            Writer.WriteMenu("Manager your personal media");
            Console.WriteLine("1. View personal Media list");
            Console.WriteLine("2. Add bulk media to a media list");
            Console.WriteLine("3. Change a media to personal list");
            GetChoice();
        }
        public void GetChoice()
        {
            bool validInput = false;
            do
            {
                string choice = Console.ReadLine().Trim();
                if (choice == "1" || choice == "2" || choice == "3")
                {
                    validInput = true;
                    RedirectChoice(choice);
                }
            } while (!validInput);
        }

        public void RedirectChoice(string choice)
        {
            if (choice == "1")
            {
                ViewAllPersonalMedia();
                return;
            }
            if (choice == "2")
            {
                BulkMediaMenu();
                return;
            }
            if (choice == "3")
            {
                ChangeSingleMedia();
                return;
            }
        }

        private void ViewAllPersonalMedia()
        {
            List<Media> favouriteList = _personalMediaDataManager.GetMediaByFavourite(SessionHandler.GetUserId());
            List<Media> yetToWatchList = _personalMediaDataManager.GetMediaByYetToWatch(SessionHandler.GetUserId());
            List<Media> watchedList = _personalMediaDataManager.GetMediaByWatched(SessionHandler.GetUserId());
            Console.WriteLine("Favourites Media List");
            ShowMediaList(favouriteList);
            Console.WriteLine("Yet to watch Media List : ");
            ShowMediaList(yetToWatchList);
            Console.WriteLine("Watched List : ");
            ShowMediaList(watchedList);
            Console.ReadKey();
        }

        private void ShowMediaList(List<Media> mediaList)
        {
            foreach (Media media in mediaList)
            {
                Console.WriteLine($"{media.MediaId} - {media.Name}");
            }
        }



        private void BulkMediaMenu()
        {
            Console.WriteLine("Which of the following list you want to add media");
            Console.WriteLine("1 -> Favourite");
            Console.WriteLine("2 -> Yet to watch");
            Console.WriteLine("3 -> Watched list");
            string choice = Console.ReadLine();

            bool isValid = false;
            do
            {
                isValid = true;
                switch (choice)
                {
                    case "1":
                        AddBulkMedia("favourite");
                        break;
                    case "2":
                        AddBulkMedia("yetToWatch");
                        break;
                    case "3":
                        AddBulkMedia("watched");
                        break;
                    default:
                        Console.WriteLine("invalid option");
                        isValid = false;
                        break;
                }
            } while (!isValid);
        }

        private void AddBulkMedia(string listName)
        {
            do
            {
                Console.WriteLine("Enter the movie id of the movie : (enter stop if you want to stop)");
                string choice = Console.ReadLine();
                if (choice == "stop")
                {
                    break;
                }
                int mediaId = Parser.ParseToInt();
                Media media = _mediaDataManager.GetMovieById(mediaId);
                if (media == null)
                {
                    Console.WriteLine("Movie not found");
                }
                else
                {
                    if (listName == "favourite")
                    {
                        _personalMediaDataManager.UpdateFavourite(SessionHandler.GetUserId(), mediaId, true);
                    }
                    if (listName == "yetToWatch")
                    {
                        _personalMediaDataManager.UpdateYetToWatch(SessionHandler.GetUserId(), mediaId, true);
                    }
                    if (listName == "watched")
                    {
                        _personalMediaDataManager.UpdateWatched(SessionHandler.GetUserId(), mediaId, true);
                    }
                }
            } while (true);
        }


        public void ChangeSingleMedia()
        {
            Console.WriteLine("Enter the media id : ");
            int mediaId = Parser.ParseToInt();
            int userId = SessionHandler.GetUserId();
            PersonalMedia personalMedia = _personalMediaDataManager.GetPersonalMedia(userId, mediaId);
            if (personalMedia == null)
            {
                personalMedia = new PersonalMedia(userId, mediaId);
            }
            Console.WriteLine("These are the marking for the movie : ");
            Console.WriteLine("Favourite -> " + personalMedia.IsFavourite);
            Console.WriteLine("Yet to Watch -> " + personalMedia.IsYetToWatch);
            Console.WriteLine("Watched -> " + personalMedia.IsWatched);
            Console.WriteLine("Do you want to toggle? 'y' or 'n' ");
            string choice = Console.ReadLine();
            if (choice == "y")
            {
                TogglePersonalMediaMarking(personalMedia);
            }
            else if (choice != "n")
            {
                Console.WriteLine("Invalid choice ");
            }
        }

        public void TogglePersonalMediaMarking(PersonalMedia personalMedia)
        {
            Console.WriteLine("Which of this you want to toggle ");
            Console.WriteLine("1 -> Favourite");
            Console.WriteLine("2 -> Yet to watch");
            Console.WriteLine("3 -> Watched list");

            bool isValid = false;
            do
            {
                string choice = Console.ReadLine();
                isValid = true;
                switch (choice)
                {
                    case "1":
                        personalMedia.IsFavourite = !personalMedia.IsFavourite;
                        break;
                    case "2":
                        personalMedia.IsYetToWatch = !personalMedia.IsYetToWatch;
                        break;
                    case "3":
                        personalMedia.IsWatched = !personalMedia.IsWatched;
                        break;
                    default:
                        Console.WriteLine("Invalid option please try again!");
                        isValid = false;
                        break;
                }
            } while (!isValid);
            _personalMediaDataManager.UpdatePersonalMedia(personalMedia);
            Console.WriteLine("Your media list has been updated successfully");
            Console.ReadKey();
        }

    }
}
