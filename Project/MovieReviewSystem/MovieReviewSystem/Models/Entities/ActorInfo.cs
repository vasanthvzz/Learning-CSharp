namespace MediaReviewSystemLibrary.Models.Entities
{
    public class ActorInfo
    {
        public ActorInfo(int actorId, int mediaId)
        {
            ActorId = actorId;
            MediaId = mediaId;
        }

        public int ActorId { get; set; }
        public int MediaId { get; set; }
    }
}
