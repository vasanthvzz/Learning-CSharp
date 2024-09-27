using MovieReviewSystem.Models;

namespace MovieReviewSystem.Library.DataHandler.Contracts
{
    internal interface IActorInfoDataHandler
    {
        public List<ActorInfo> GetAll();
        public ActorInfo GetById(int id);
        public void Add(ActorInfo actorInfo);
        public void Remove(ActorInfo actorInfo);
    }
}
