using MovieReviewSystem.Library.DataHandler.Contracts;
using MovieReviewSystem.Models;

namespace MovieReviewSystem.Library.DataHandler
{
    internal class ReactionDataHandler : IReactionDataHandler
    {
        private MovieDatabase _database;
        public ReactionDataHandler()
        {
            _database = MovieDatabase.GetDB();
        }

        public void AddReaction(Reaction reaction)
        {
            _database.AddReaction(reaction);
        }

        public List<Reaction> GetAll()
        {
            return _database.GetReactionList();
        }

    }
}
