namespace MediaReviewSystemLibrary.Models.Entities
{
    public class Reaction
    {
        public int UserId { get; set; }
        public int MediaId { get; set; }
        public ReactionType MediaReaction { get; set; }

        public Reaction(int userId, int mediaId)
        {
            UserId = userId;
            MediaId = mediaId;
        }

        public Reaction(int userId, int mediaId, ReactionType reactionType)
        {
            UserId = userId;
            MediaId = mediaId;
            MediaReaction = reactionType;
        }

    }
}
