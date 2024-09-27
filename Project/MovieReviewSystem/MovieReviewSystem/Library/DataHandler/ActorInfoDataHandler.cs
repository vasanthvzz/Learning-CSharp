using MovieReviewSystem.Library.DataHandler.Contracts;
using MovieReviewSystem.Models;

namespace MovieReviewSystem.Library.DataHandler
{
    internal class ActorInfoDataHandler : IActorInfoDataHandler
    {
        private MovieDatabase _database;

        public ActorInfoDataHandler()
        {
            _database = MovieDatabase.GetDB();
        }

        public List<ActorInfo> GetAll()
        {
            return _database.GetActorInfoList();
        }

        public ActorInfo GetById(int id)
        {
            var query = _database.GetActorInfoList().Where(actorInfo => actorInfo.ActorId == id);
            return query.FirstOrDefault();
        }
        public void Add(ActorInfo actorInfo)
        {
            _database.AddActorInfo(actorInfo);
        }
        public void Remove(ActorInfo actorInfo)
        {
            _database.RemoveActorInfo(actorInfo);
        }
    }
}
