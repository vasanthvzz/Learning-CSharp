using CommonClassLibrary;
using MediaReviewSystem.Database;
using MediaReviewSystemLibrary.Domain;
using MediaReviewSystemLibrary.Models;
using MediaReviewSystemLibrary.Models.Entities;

namespace MediaReviewSystemLibrary.Data
{
    public class GetAllMediaDataManager : MediaDataManagerBase, IGetAllMediaDataManager
    {
        private IMediaDatabase _db;
        public GetAllMediaDataManager()
        {
            _db = MediaDatabase.GetDb();
        }

        public void GetAllMedia(ICallback<GetAllMediaResponse> callback)
        {
            try
            {
                List<Media> mediaList = _db.GetMediaList();
                if (mediaList == null)
                {
                    callback?.OnFailure(new Exception("unable to retrieve Media from the database"));
                    return;
                }
                if (mediaList.Count == 0)
                {
                    callback?.OnFailure(new Exception("Found no Media from the database"));
                    return;
                }
                List<CompactMediaBObj> compactMediaList = new List<CompactMediaBObj>();
                foreach (var media in mediaList)
                {
                    compactMediaList.Add(GetCompactMedia(media));
                }
                GetAllMediaResponse res = new GetAllMediaResponse(compactMediaList);
                ZResponse<GetAllMediaResponse> response = new ZResponse<GetAllMediaResponse>(res);
                callback?.OnSuccess(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
