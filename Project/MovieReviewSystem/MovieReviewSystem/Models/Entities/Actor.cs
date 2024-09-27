
namespace MediaReviewSystemLibrary.Models.Entities
{
    public class Actor
    {
        public int ActorId { get; set; }
        public string ActorName { get; set; }

        public Actor(int actorId, string actorName)
        {
            ActorId = actorId;
            ActorName = actorName;
        }
    }
}
