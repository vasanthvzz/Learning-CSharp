using CommonClassLibrary;
using MediaReviewSystem.Database;
using MediaReviewSystemLibrary.Domain;
using MediaReviewSystemLibrary.Models;
using MediaReviewSystemLibrary.Models.Entities;

namespace MediaReviewSystemLibrary.Data
{
    public class FilterMediaByTagDataManager : MediaDataManagerBase, IFilterMediaByTagDataManager
    {
        private IMediaDatabase _db;

        public FilterMediaByTagDataManager()
        {
            _db = MediaDatabase.GetDb();
        }

        public void FilterMediaByTag(FilterMediaByTagRequest request, FilterMediaByTagUseCaseCallback callback)
        {
            try
            {
                if (_db == null)
                {
                    callback?.OnFailure(new Exception("Unable to connect to the database"));
                    return;
                }

                List<Media> mediaList = _db.GetMediaList();
                List<TagInfo> tagInfos = _db.GetTagInfoList();
                if (mediaList == null || tagInfos == null)
                {
                    callback?.OnFailure(new Exception("Unable to fetch data from the database"));
                    return;
                }
                // Filter media by the provided tag
                List<TagInfo> filteredTagInfos = _db.GetTagInfoList()
                                         .Where(tagInfo => request.Tags.Contains(tagInfo.TagId))
                                         .ToList();

                List<long> filteredMediaIds = new List<long>();
                foreach (var tagInfo in filteredTagInfos)
                {
                    filteredMediaIds.Add(tagInfo.MediaId);
                }

                filteredMediaIds = filteredMediaIds.Distinct().ToList();

                List<CompactMediaBObj> compactMediaList = new List<CompactMediaBObj>();
                foreach (var mediaId in filteredMediaIds)
                {
                    compactMediaList.Add(GetCompactMedia(mediaId));
                }

                var response = new FilterMediaByTagResponse(compactMediaList);
                var zResponse = new ZResponse<FilterMediaByTagResponse>(response);
                callback?.OnSuccess(zResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }

    public interface IFilterMediaByTagDataManager
    {
        void FilterMediaByTag(FilterMediaByTagRequest request, FilterMediaByTagUseCaseCallback callback);
    }
}
