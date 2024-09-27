namespace MediaReviewSystemLibrary.Models.Entities
{
    public class Reaction
    {
        public long UserId { get; set; }
        public long MediaId { get; set; }
        public ReactionType MediaReaction { get; set; }

        public Reaction(long userId, long mediaId)
        {
            UserId = userId;
            MediaId = mediaId;
            MediaReaction = ReactionType.NEUTRAL;
        }

        public Reaction(long userId, long mediaId,ReactionType reaction)
        {
            UserId = userId;
            MediaId = mediaId;
            MediaReaction = reaction;
        }
    }
}
