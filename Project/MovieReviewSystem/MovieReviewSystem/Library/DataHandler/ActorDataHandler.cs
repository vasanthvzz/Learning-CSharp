using MovieReviewSystem.Library.DataHandler.Contracts;
using MovieReviewSystem.Models;

namespace MovieReviewSystem.Library.DataHandler
{
    internal class ActorDataHandler : IActorDataHandler
    {
        private MovieDatabase _database;

        public ActorDataHandler()
        {
            _database = MovieDatabase.GetDB();
        }

        public List<Actor> GetAll()
        {
            return _database.GetActorList();
        }

        public Actor GetById(int id)
        {
            var query = _database.GetActorList().Where(actor => actor.ActorId == id);
            return query.FirstOrDefault();
        }
        public void Add(Actor actor)
        {
            _database.AddActor(actor);
        }
        public void Remove(Actor actor)
        {
            _database.RemoveActor(actor);
        }
    }
}
