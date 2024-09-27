using MovieReviewSystem.Library.DataHandler;
using MovieReviewSystem.Library.DataHandler.Contracts;
using MovieReviewSystem.Models;

namespace MovieReviewSystem.Library.DataManager
{
    internal class ActorDataManager
    {
        private readonly IActorDataHandler _actorDataHandler;
        private readonly IActorInfoDataHandler _actorInfoDataHandler;
        private readonly IMediaDataHandler _mediaDataHandler;

        public ActorDataManager()
        {
            _actorDataHandler = new ActorDataHandler();
            _actorInfoDataHandler = new ActorInfoDataHandler();
            _mediaDataHandler = new MediaDataHandler();
        }

        public List<Actor> GetAll()
        {
            return _actorDataHandler.GetAll();
        }

        public List<Media> GetMediaByActorId(int actorId)
        {
            List<ActorInfo> actorInfoList = _actorInfoDataHandler.GetAll().Where(actorInfo => actorInfo.ActorId == actorId).ToList();
            List<Media> mediaList = new List<Media>();
            foreach (ActorInfo actorInfo in actorInfoList)
            {
                Media media = _mediaDataHandler.GetById(actorInfo.MediaId);
                mediaList.Add(media);
            }
            return mediaList;
        }

        public List<string> GetActors(int mediaId)
        {
            List<Actor> actors = _actorDataHandler.GetAll();
            List<string> actorNames = _actorInfoDataHandler.GetAll()
                .Where(actorInfo => actorInfo.MediaId == mediaId)
                .Join(actors,
                      actorInfo => actorInfo.ActorId,
                      actor => actor.ActorId,
                      (actorInfo, actor) => actor.ActorName) // This ensures unique actor names
                .ToList();
            return actorNames;
        }

        public void AddActor(int actorId, string actorName)
        {
            _actorDataHandler.Add(new Actor(actorId, actorName));
        }


        public void AddActorInfo(int actorId, int mediaId)
        {
            ActorInfo actorInfo = _actorInfoDataHandler.GetAll().FirstOrDefault(actorInfo => actorInfo.MediaId == mediaId && actorInfo.ActorId == actorId);
            if (actorInfo == null)
            {
                if (isValidActor(actorId) && isValidMedia(mediaId))
                {
                    actorInfo = new ActorInfo(actorId, mediaId);
                    _actorInfoDataHandler.Add(actorInfo);
                }
                else
                {
                    Console.WriteLine("Invalid actor id or media id");
                }
            }
            else
            {
                Console.WriteLine("actor already present");
            }
        }

        public void RemoveActor(int actorId, int mediaId)
        {
            ActorInfo actorInfo = new ActorInfo(actorId, mediaId);
            _actorInfoDataHandler.Remove(actorInfo);
        }

        private bool isValidMedia(int mediaId)
        {
            var media = _mediaDataHandler.GetById(mediaId);
            return media != null;
        }

        public bool isValidActor(int actorId)
        {
            var actor = _actorDataHandler.GetById(actorId);
            return actor != null;
        }


        public List<Media> GetMedia(int actorId)
        {
            List<ActorInfo> actorInfoList = _actorInfoDataHandler.GetAll().Where(actorInfo => actorInfo.ActorId == actorId).ToList();
            List<Media> mediaList = new List<Media>();
            foreach (ActorInfo actorInfo in actorInfoList)
            {
                mediaList.Add(_mediaDataHandler.GetById(actorInfo.MediaId));
            }
            return mediaList;
        }


    }
}
