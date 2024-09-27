using CommonClassLibrary;
using MediaReviewSystem.Database;
using MediaReviewSystemLibrary.Domain;
using MediaReviewSystemLibrary.Models;
using MediaReviewSystemLibrary.Models.Entities;

namespace MediaReviewSystemLibrary.Data
{
    public class SearchMediaDataManager : MediaDataManagerBase, ISearchMediaDataManager
    {
        private IMediaDatabase _db;

        public SearchMediaDataManager()
        {
            _db = MediaDatabase.GetDb();
        }

        public void SearchMedia(SearchMediaRequest request, SearchMediaUseCaseCallback callback)
        {
            try
            {
                if (_db == null)
                {
                    callback?.OnFailure(new Exception("Unable to connect to the database"));
                    return;
                }

                List<Media> mediaList = _db.GetMediaList();
                List<Tag> tags = _db.GetTagList();
                List<TagInfo> tagInfos = _db.GetTagInfoList();

                if (mediaList == null || tags == null || tagInfos == null)
                {
                    callback?.OnFailure(new Exception("Unable to fetch data from the database"));
                    return;
                }
                string[] keywords = request.Keywords;
                List<long> mediaIds = new List<long>();
                //split the movie names by space and add them if they are in keywords
                foreach (Media media in mediaList)
                {
                    string[] mediaName = media.Name.ToLower().Split();
                    foreach (string name in mediaName)
                    {
                        if (keywords.Contains(name))
                        {
                            mediaIds.Add(media.MediaId);
                        }
                    }
                }
                //search in the tags name and put that if the tag name exist in keyword
                List<int> tagIds = new List<int>();
                foreach (Tag tag in tags)
                {
                    if (keywords.Intersect(tag.TagName.ToLower().Split()).Any())
                    {
                        tagIds.Add(tag.TagId);
                    }
                }
                //fetch media id based on the tag ids
                foreach (TagInfo tagInfo in tagInfos)
                {
                    if (tagIds.Contains(tagInfo.TagId))
                    {
                        mediaIds.Add(tagInfo.MediaId);
                    }
                }
                //Remove Duplicate media ids
                mediaIds = mediaIds.Distinct().ToList();
                foreach (long id in mediaIds) { Console.WriteLine(id); }
                //Convert media id into compact media bobj
                List<CompactMediaBObj> resultMedia = new List<CompactMediaBObj>();
                foreach (long mediaId in mediaIds)
                {
                    resultMedia.Add(GetCompactMedia(mediaId));
                }
                //Create response and send to the callback
                SearchMediaResponse response = new SearchMediaResponse(resultMedia);
                ZResponse<SearchMediaResponse> zResponse = new ZResponse<SearchMediaResponse>(response);
                callback?.OnSuccess(zResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}

