using MovieReviewSystem.Library.DataHandler.Contracts;
using MovieReviewSystem.Models;

namespace MovieReviewSystem.Library.DataHandler
{
    internal class MediaDataHandler : IMediaDataHandler
    {
        private MovieDatabase _database;

        public MediaDataHandler()
        {
            _database = MovieDatabase.GetDB();
        }

        public void Add(Media media)
        {
            _database.AddMedia(media);
        }

        public void Delete(int id)
        {
            _database.RemoveMedia(GetById(id));
        }

        public void Remove(Media media)
        {
            _database.RemoveMedia(media);
        }

        public List<Media> GetAll()
        {
            return _database.GetMediaList();
        }

        public int GetCount()
        {
            return _database.GetMediaList().Count;
        }

        public Media GetById(int id)
        {
            var query = _database.GetMediaList().Where(media => media.MediaId == id);
            return query.FirstOrDefault();
        }

        public void Update(Media entity)
        {
            Media media = GetById(entity.MediaId);
            if (media != null)
            {
                media.MediaId = entity.MediaId;
                media.Name = entity.Name;
                media.Description = entity.Description;
                media.ReleaseDate = entity.ReleaseDate;
                media.MediaType = entity.MediaType;
            }
        }
    }
}
