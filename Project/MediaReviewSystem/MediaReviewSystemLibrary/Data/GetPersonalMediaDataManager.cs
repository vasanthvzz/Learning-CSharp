using CommonClassLibrary;
using MediaReviewSystem.Database;
using MediaReviewSystemLibrary.Domain;
using MediaReviewSystemLibrary.Models;
using MediaReviewSystemLibrary.Models.Entities;

namespace MediaReviewSystemLibrary.Data
{
    public class GetPersonalMediaDataManager : MediaDataManagerBase, IGetPersonalMediaDataManager
    {
        private IMediaDatabase _db;
        public GetPersonalMediaDataManager()
        {
            _db = MediaDatabase.GetDb();

        }

        public void GetPesonalMediaList(GetPersonalMediaRequest req, GetPersonalMediaUseCaseCallback useCaseCallback)
        {
            try
            {
                List<PersonalMedia> personalMediaList = _db.GetPersonalMediaList();
                if (_db == null)
                {
                    useCaseCallback?.OnFailure(new Exception("Unable to connect to the database"));
                    return;
                }
                if (personalMediaList == null)
                {
                    useCaseCallback?.OnFailure(new Exception("Unable to fetch data from the database"));
                    return;
                }
                //Filtering personal Media which has the userId
                GetPersonalMediaResponse response = new GetPersonalMediaResponse();
                foreach (PersonalMedia personalMedia in personalMediaList)
                {
                    if (personalMedia.UserId != req.UserId)
                    {
                        continue;
                    }
                    CompactMediaBObj media = GetCompactMedia(personalMedia.MediaId);
                    if (media == null)
                    {
                        useCaseCallback?.OnFailure(new Exception("Internal error personal Media added without actual Media"));
                        continue;
                    }
                    if (personalMedia.IsFavourite)
                    {
                        response.FavouriteMedia.Add(media);
                    }
                    if (personalMedia.HasWatched)
                    {
                        response.HasWatchedMedia.Add(media);
                    }
                    if (personalMedia.IsYetToWatch)
                    {
                        response.YetToWatchMedia.Add(media);
                    }
                }
                ZResponse<GetPersonalMediaResponse> zResponse = new ZResponse<GetPersonalMediaResponse>(response);
                useCaseCallback?.OnSuccess(zResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
