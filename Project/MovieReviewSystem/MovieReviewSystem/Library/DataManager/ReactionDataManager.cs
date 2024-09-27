using MovieReviewSystem.Library.DataHandler;
using MovieReviewSystem.Models;

namespace MovieReviewSystem.Library.DataManager
{
    internal class ReactionDataManager
    {
        private readonly ReactionDataHandler _reactionDataHandler;

        public ReactionDataManager()
        {
            _reactionDataHandler = new ReactionDataHandler();
        }

        public void UpdateReaction(int userId, int mediaId, ReactionType react)
        {
            Reaction reaction = RetrieveReaction(userId, mediaId);
            if (reaction == null)
            {
                reaction = new Reaction(userId, mediaId);
                reaction.MediaReaction = react;
                _reactionDataHandler.AddReaction(reaction);
            }
            else
            {
                reaction.MediaReaction = react;
            }
        }

        public List<Reaction> GetAll()
        {
            return _reactionDataHandler.GetAll();
        }

        public void UpdateReaction(Reaction reaction)
        {
            UpdateReaction(reaction.UserId, reaction.MediaId, reaction.MediaReaction);
        }



        public Reaction RetrieveReaction(int userId, int mediaId)
        {
            return _reactionDataHandler.GetAll().FirstOrDefault(reaction =>
            reaction.UserId == userId && reaction.MediaId == mediaId);
        }

        public int ReactionCount(int mediaId, ReactionType reactionType)
        {
            return _reactionDataHandler.GetAll()
                .Count(reaction => reaction.MediaId == mediaId && reaction.MediaReaction == reactionType);
        }

    }
}
