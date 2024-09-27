using MovieReviewSystem.Library.DataHandler;
using MovieReviewSystem.Library.DataManager;
using MovieReviewSystem.Models;

namespace MovieReviewSystem.Views
{
    internal class ManageMediaView : IView
    {
        private Media media;
        private PersonalMediaDataManager _personalMediaDataManager;
        public ManageMediaView(Media media)
        {
            this.media = media;
            _personalMediaDataManager = new PersonalMediaDataManager();
        }

        public void Initialize()
        {
            Writer.WriteMenu("Manage media Review : ");
            Writer.WriteMedia(media);
            ShowMenu();
        }

        private void ShowMenu()
        {
            Console.WriteLine("1. Add Review");
            Console.WriteLine("2. Add Comment");
            Console.WriteLine("3. React Media");
            ShowPersonalMedia();
            string choice = Console.ReadLine();
        }

        private void ShowPersonalMedia()
        {
            PersonalMedia personalMedia = _personalMediaDataManager.GetById(SessionHandler.GetUserId(), media.MediaId);
            if (personalMedia == null)
            {
                personalMedia = new PersonalMedia(SessionHandler.GetUserId(), media.MediaId);
                _personalMediaDataManager.UpdatePersonalMedia(personalMedia);
            }
            Console.WriteLine($"4. {(personalMedia.IsFavourite ? "Remove from" : "Add to")} favourites");
            Console.WriteLine($"5. {(personalMedia.IsYetToWatch ? "Remove from" : "Add to")} yet to watch");
            Console.WriteLine($"6. {(personalMedia.IsWatched ? "Remove from" : "Add to")} watched");
        }
    }
}
