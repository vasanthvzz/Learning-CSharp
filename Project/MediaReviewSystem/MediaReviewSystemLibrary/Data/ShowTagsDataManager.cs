using CommonClassLibrary;
using MediaReviewSystem.Database;
using MediaReviewSystemLibrary.Domain;
using MediaReviewSystemLibrary.Models.Entities;

namespace MediaReviewSystemLibrary.Data
{
    internal class ShowTagsDataManager : IShowTagsDataManager
    {
        private MediaDatabase _db;

        public ShowTagsDataManager()
        {
            _db = MediaDatabase.GetDb();
        }

        public void GetMediaTagList(ShowTagsRequest request, ShowTagsUseCaseCallback callback)
        {
            try
            {
                if (_db == null)
                {
                    callback?.OnFailure(new Exception("Unable to connect to the database"));
                    return;
                }
                List<Tag> tagList = _db.GetTagList();
                if (tagList == null)
                {
                    callback?.OnFailure(new Exception("Unable to fetch data from the database"));
                    return;
                }
                ShowTagsResponse response = new ShowTagsResponse(tagList);
                ZResponse<ShowTagsResponse> zResponse = new ZResponse<ShowTagsResponse>(response);
                callback?.OnSuccess(zResponse);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
