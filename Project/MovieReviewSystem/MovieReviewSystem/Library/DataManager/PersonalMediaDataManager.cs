using MovieReviewSystem.DataLoader;
using MovieReviewSystem.Library.DataHandler;
using MovieReviewSystem.Models;

namespace MovieReviewSystem.Library.DataManager
{
    internal class PersonalMediaDataManager
    {
        private readonly PersonalMediaDataHandler _personalMediaDataHandler;
        private readonly MediaDataHandler _mediaDataHandler;

        public PersonalMediaDataManager()
        {
            _mediaDataHandler = new MediaDataHandler();
            _personalMediaDataHandler = new PersonalMediaDataHandler();
        }

        public List<PersonalMedia> GetByUserId(int userId)
        {
            List<PersonalMedia> personalMediaList = _personalMediaDataHandler.GetAll();
            return personalMediaList.Where(personalMedia => personalMedia.UserId == userId).ToList();
        }

        public PersonalMedia GetById(int userId, int mediaId)
        {
            List<PersonalMedia> personalMediaList = _personalMediaDataHandler.GetAll();
            return personalMediaList.FirstOrDefault(personalMedia => personalMedia.UserId == userId && personalMedia.MediaId == mediaId);
        }

        public List<PersonalMedia> GetByMediaId(int mediaId)
        {
            List<PersonalMedia> personalMediaList = _personalMediaDataHandler.GetAll();
            return personalMediaList.Where(personalMedia => personalMedia.MediaId == mediaId).ToList();
        }

        public void UpdatePersonalMedia(PersonalMedia personalMedia)
        {
            PersonalMedia personalMedia1 = GetPersonalMedia(personalMedia.UserId, personalMedia.MediaId);
            if (personalMedia1 == null)
            {
                _personalMediaDataHandler.StorePersonalMedia(personalMedia);
            }
            else
            {
                personalMedia1.IsFavourite = personalMedia.IsFavourite;
                personalMedia1.IsWatched = personalMedia.IsWatched;
                personalMedia1.IsYetToWatch = personalMedia.IsYetToWatch;
            }
        }

        public List<Media> GetMediaByFavourite(int userId)
        {
            List<PersonalMedia> personalMediaList = GetByUserId(userId);
            List<PersonalMedia> favouritePersonalMedia = personalMediaList.Where(personalMedia => personalMedia.IsFavourite == true).ToList();
            List<Media> mediaList = favouritePersonalMedia
                .Select(personalMedia => _mediaDataHandler.GetById(personalMedia.MediaId))
                .ToList();
            return mediaList;
        }

        public List<Media> GetMediaByWatched(int userId)
        {
            List<PersonalMedia> personalMediaList = GetByUserId(userId);
            List<PersonalMedia> favouritePersonalMedia = personalMediaList.Where(personalMedia => personalMedia.IsWatched == true).ToList();
            List<Media> mediaList = favouritePersonalMedia
                .Select(personalMedia => _mediaDataHandler.GetById(personalMedia.MediaId))
                .ToList();
            return mediaList;
        }

        public List<Media> GetMediaByYetToWatch(int userId)
        {
            List<PersonalMedia> personalMediaList = GetByUserId(userId);
            List<PersonalMedia> favouritePersonalMedia = personalMediaList.Where(personalMedia => personalMedia.IsYetToWatch == true).ToList();
            List<Media> mediaList = favouritePersonalMedia
                .Select(personalMedia => _mediaDataHandler.GetById(personalMedia.MediaId))
                .ToList();
            return mediaList;
        }

        public PersonalMedia GetPersonalMedia(int userId, int mediaId)
        {
            return _personalMediaDataHandler.GetAll().FirstOrDefault(personalMedia =>
                personalMedia.UserId == userId && personalMedia.MediaId == mediaId);
        }

        public void UpdateFavourite(int userId, int mediaId, bool favourite)
        {
            PersonalMedia personalMedia = GetPersonalMedia(userId, mediaId);
            if (personalMedia == null)
            {
                personalMedia = new PersonalMedia(userId, mediaId);
                _personalMediaDataHandler.StorePersonalMedia(personalMedia);
            }
            personalMedia.IsFavourite = favourite;
        }

        public void UpdateYetToWatch(int userId, int mediaId, bool yetToWatch)
        {
            PersonalMedia personalMedia = GetPersonalMedia(userId, mediaId);
            if (personalMedia == null)
            {
                personalMedia = new PersonalMedia(userId, mediaId);
                _personalMediaDataHandler.StorePersonalMedia(personalMedia);
            }
            personalMedia.IsYetToWatch = yetToWatch;
        }

        public void UpdateWatched(int userId, int mediaId, bool watched)
        {
            PersonalMedia personalMedia = GetPersonalMedia(userId, mediaId);
            if (personalMedia == null)
            {
                personalMedia = new PersonalMedia(userId, mediaId);
                _personalMediaDataHandler.StorePersonalMedia(personalMedia);
            }
            personalMedia.IsWatched = watched;
        }

    }
}
