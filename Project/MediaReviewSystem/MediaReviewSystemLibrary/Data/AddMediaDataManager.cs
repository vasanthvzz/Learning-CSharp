using CommonClassLibrary;
using MediaReviewSystem.Database;
using MediaReviewSystemLibrary.Domain;
using MediaReviewSystemLibrary.Models.Entities;

namespace MediaReviewSystemLibrary.Data
{
    public class AddMediaDataManager : IAddMediaDataManager
    {
        private MediaDatabase _db;

        public AddMediaDataManager()
        {
            _db = MediaDatabase.GetDb();
        }

        public void AddMedia(AddMediaRequest request, AddMediaUseCaseCallback callback)
        {
            try
            {
                if (_db == null)
                {
                    callback?.OnFailure(new Exception("Unable to connect to the database"));
                    return;
                }

                List<Media> mediaList = _db.GetMediaList();
                List<TagInfo> tagInfoList = new List<TagInfo>();
                if (mediaList == null || tagInfoList == null)
                {
                    callback?.OnFailure(new Exception("Unable to fetch Media data from database"));
                    return;
                }

                Media media = mediaList.FirstOrDefault(media => media.MediaId == request.Media.MediaId);
                if (media == null)
                {
                    _db.AddMedia(request.Media);
                }
                else
                {
                    callback?.OnFailure(new Exception("Media exist with the Media id!"));
                    return;
                }
                foreach (int tagId in request.Tags)
                {
                    TagInfo tagInfo = tagInfoList.FirstOrDefault(tagInfo => tagInfo.TagId == tagId);
                    if (tagInfo == null)
                    {
                        tagInfoList.Add(new TagInfo(tagId, request.Media.MediaId));
                    }
                }
                var response = new AddMediaResponse(request.Media.MediaId);
                var zResponse = new ZResponse<AddMediaResponse>(response);
                callback?.OnSuccess(zResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
