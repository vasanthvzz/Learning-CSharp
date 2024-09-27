using MovieReviewSystem.Library.DataHandler.Contracts;
using MovieReviewSystem.Models;

namespace MovieReviewSystem.Library.DataHandler
{
    internal class TagDataHandler : ITagDataHandler
    {
        private MovieDatabase _database;

        public TagDataHandler()
        {
            _database = MovieDatabase.GetDB();
        }

        public List<Tag> GetAll()
        {
            return _database.GetTagList();
        }

        public Tag GetById(int id)
        {
            var query = _database.GetTagList().Where(tag => tag.TagId == id);
            return query.FirstOrDefault();
        }
        public void Add(Tag tag)
        {
            _database.AddTag(tag);
        }
        public void Remove(Tag tag)
        {
            _database.RemoveTag(tag);
        }
    }
}
