
using MovieReviewSystem.Library.DataHandler.Contracts;
using MovieReviewSystem.Models;

namespace MovieReviewSystem.Library.DataHandler
{
    internal class PersonalMediaDataHandler : IPersonalMediaDataHandler
    {
        private MovieDatabase _database;

        public PersonalMediaDataHandler()
        {
            _database = MovieDatabase.GetDB();
        }

        public List<PersonalMedia> GetAll()
        {
            return _database.GetPersonalMediaList();
        }

        public void StorePersonalMedia(PersonalMedia personalMedia)
        {
            _database.AddPersonalMedia(personalMedia);
        }
    }
}
