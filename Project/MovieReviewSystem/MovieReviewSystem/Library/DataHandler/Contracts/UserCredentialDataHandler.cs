using MovieReviewSystem.Models.Entities;

namespace MovieReviewSystem.Library.DataHandler.Contracts
{
    class UserCredentialDataHandler
    {
        private MovieDatabase _database;
        public UserCredentialDataHandler()
        {
            _database = MovieDatabase.GetDB();
        }
        //public UserCredential GetById(int id)
        //{
        //    _database.getUs
        //}
    }
}
