using MovieReviewSystem.Models;

namespace MovieReviewSystem.Library.DataHandler.Contracts
{
    internal interface IReactionDataHandler
    {
        public void AddReaction(Reaction reaction);
        public List<Reaction> GetAll();
    }
}
