
using MovieReviewSystem.Library.DataHandler;
using MovieReviewSystem.Models;

namespace MovieReviewSystem.Library.DataManager
{
    internal class TagDataManager
    {
        private readonly TagDataHandler _tagDataHandler;
        private readonly TagInfoDataHandler _tagInfoDataHandler;
        private readonly MediaDataHandler _mediaDataHandler;

        public TagDataManager()
        {
            _tagDataHandler = new TagDataHandler();
            _tagInfoDataHandler = new TagInfoDataHandler();
            _mediaDataHandler = new MediaDataHandler();
        }

        public List<string> GetTags(int mediaId)
        {
            List<Tag> tags = _tagDataHandler.GetAll();
            List<string> tagNames = _tagInfoDataHandler.GetAll()
                .Where(tagInfo => tagInfo.MediaId == mediaId)
                .Join(tags,
                      tagInfo => tagInfo.TagId,   // Foreign key in TagInfo
                      tag => tag.TagId,           // Primary key in Tag
                      (tagInfo, tag) => tag.TagName)  // Select the TagName from Tag
                .ToList();
            return tagNames;
        }

        public List<Media> GetMediaByTag(int tagId)
        {
            List<TagInfo> tagInfoList = _tagInfoDataHandler.GetAll().Where(tagInfo => tagInfo.TagId == tagId).ToList();
            List<Media> mediaList = new List<Media>();
            foreach (TagInfo tagInfo in tagInfoList)
            {
                Media media = _mediaDataHandler.GetById(tagInfo.MediaId);
                mediaList.Add(media);
            }
            return mediaList;
        }

        public void AddTag(int tagId, int mediaId)
        {
            TagInfo tagInfo = _tagInfoDataHandler.GetAll().FirstOrDefault(tagInfo => tagInfo.MediaId == mediaId && tagInfo.TagId == tagId);
            if (tagInfo == null)
            {
                if (isValidTag(tagId) && isValidMedia(mediaId))
                {
                    tagInfo = new TagInfo(tagId, mediaId);
                    _tagInfoDataHandler.Add(tagInfo);
                }
                else
                {
                    Console.WriteLine("Invalid tag id or media id");
                }
            }
            else
            {
                Console.WriteLine("Tag already present");
            }
        }



        private bool isValidMedia(int mediaId)
        {
            var media = _mediaDataHandler.GetById(mediaId);
            return media != null;
        }


        public void RemoveTag(int tagId, int mediaId)
        {
            TagInfo tagInfo = new TagInfo(tagId, mediaId);
            _tagInfoDataHandler.Remove(tagInfo);
        }

        public bool isValidTag(int tagId)
        {
            return _tagDataHandler.GetById(tagId) != null;
        }

        public List<Media> GetMedia(int tagId)
        {
            List<TagInfo> tagInfoList = _tagInfoDataHandler.GetAll().Where(tagInfo => tagInfo.TagId == tagId).ToList();
            List<Media> mediaList = new List<Media>();
            foreach (TagInfo tagInfo in tagInfoList)
            {
                mediaList.Add(_mediaDataHandler.GetById(tagInfo.MediaId));
            }
            return mediaList;
        }

        public List<Tag> GetAll()
        {
            return _tagDataHandler.GetAll();
        }

    }
}
