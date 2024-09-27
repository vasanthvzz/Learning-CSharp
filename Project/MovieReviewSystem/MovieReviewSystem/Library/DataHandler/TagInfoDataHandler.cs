using MovieReviewSystem.Library.DataHandler.Contracts;
using MovieReviewSystem.Models;

namespace MovieReviewSystem.Library.DataHandler
{
    internal class TagInfoDataHandler : ITagInfoDataHandler
    {
        private MovieDatabase _database;

        public TagInfoDataHandler()
        {
            _database = MovieDatabase.GetDB();
        }

        public List<TagInfo> GetAll()
        {
            return _database.GetTagInfoList();
        }

        public void Add(TagInfo tagInfo)
        {
            _database.AddTagInfo(tagInfo);
        }

        public void Remove(TagInfo tagInfo)
        {
            _database.RemoveTagInfo(tagInfo);
        }

    }
}
