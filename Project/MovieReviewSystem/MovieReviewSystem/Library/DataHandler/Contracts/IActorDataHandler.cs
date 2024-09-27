using MovieReviewSystem.Models;

namespace MovieReviewSystem.Library.DataHandler.Contracts
{
    internal interface IActorDataHandler
    {
        public List<Actor> GetAll();
        public Actor GetById(int id);
        public void Add(Actor actor);
        public void Remove(Actor actor);
    }
}
