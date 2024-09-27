using CommonClassLibrary;
using MediaReviewSystem.Database;
using MediaReviewSystemLibrary.Domain;
using MediaReviewSystemLibrary.Models;
using MediaReviewSystemLibrary.Models.Entities;

namespace MediaReviewSystemLibrary.Data
{
    public class GetReactedMediaDataManager : MediaDataManagerBase, IGetReactedMediaDataManager
    {
        private IMediaDatabase _db;

        public GetReactedMediaDataManager()
        {
            _db = MediaDatabase.GetDb();
        }

        public void FetchData(GetReactedMediaRequest request, GetReactedMediaUseCaseCallback callback)
        {
            try
            {
                if (_db == null)
                {
                    callback?.OnFailure(new Exception("Unable to connect to the database"));
                    return;
                }

                // Get the Media and reaction lists from the database
                var mediaList = _db.GetMediaList();
                var reactionList = _db.GetReactionList();

                if (mediaList == null || reactionList == null)
                {
                    callback?.OnFailure(new Exception("Unable to fetch data from the database"));
                    return;
                }

                // Get the user ID from the request
                long userId = request.UserId;

                // Create lists for each reaction type
                var likedMedia = new List<CompactMediaBObj>();
                var dislikedMedia = new List<CompactMediaBObj>();
                var funnyMedia = new List<CompactMediaBObj>();
                var sadMedia = new List<CompactMediaBObj>();
                var angryMedia = new List<CompactMediaBObj>();
                var fearMedia = new List<CompactMediaBObj>();

                // Iterate through the reactions and categorize based on reaction type
                foreach (var reaction in reactionList.Where(r => r.UserId == userId))
                {
                    var media = mediaList.FirstOrDefault(m => m.MediaId == reaction.MediaId);
                    if (media == null)
                    {
                        callback?.OnFailure(new Exception("Internal error : Reaction without Media exist"));
                        return;
                    } // Skip if the Media is not found

                    switch (reaction.MediaReaction)
                    {
                        case ReactionType.LIKE:
                            likedMedia.Add(GetCompactMedia(media));
                            break;
                        case ReactionType.DISLIKE:
                            dislikedMedia.Add(GetCompactMedia(media));
                            break;
                        case ReactionType.FUNNY:
                            funnyMedia.Add(GetCompactMedia(media));
                            break;
                        case ReactionType.SAD:
                            sadMedia.Add(GetCompactMedia(media));
                            break;
                        case ReactionType.ANGRY:
                            angryMedia.Add(GetCompactMedia(media));
                            break;
                        case ReactionType.FEAR:
                            fearMedia.Add(GetCompactMedia(media));
                            break;
                        default:
                            break;
                    }
                }

                // Create response object with categorized Media lists
                var response = new GetReactedMediaResponse(
                    likedMedia,
                    dislikedMedia,
                    funnyMedia,
                    sadMedia,
                    angryMedia,
                    fearMedia
                );

                // Send the response back via callback
                var zResponse = new ZResponse<GetReactedMediaResponse>(response);
                callback?.OnSuccess(zResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }
}
