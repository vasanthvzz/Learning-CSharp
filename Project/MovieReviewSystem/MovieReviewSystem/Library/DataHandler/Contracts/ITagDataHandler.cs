using MovieReviewSystem.Models;

namespace MovieReviewSystem.Library.DataHandler.Contracts
{
    internal interface ITagDataHandler
    {
        public List<Tag> GetAll();
        public Tag GetById(int id);
        public void Add(Tag tag);
        public void Remove(Tag tag);
    }
}
