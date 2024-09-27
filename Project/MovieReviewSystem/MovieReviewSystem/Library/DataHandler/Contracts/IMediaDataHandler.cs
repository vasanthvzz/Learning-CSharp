using MovieReviewSystem.Models;

namespace MovieReviewSystem.Library.DataHandler.Contracts
{
    internal interface IMediaDataHandler
    {
        public void Add(Media media);
        public void Delete(int id);
        public List<Media> GetAll();
        public int GetCount();
        public Media GetById(int id);
        public void Update(Media entity);
    }
}
