using MediaReviewSystemLibrary.Models.Entities;

namespace MediaReviewSystemLibrary.Models
{
    public class CompactMediaBObj
    {
        public long MediaId { get; set; }
        public string MediaName { get; set; }
        public float Rating { get; set; }
        public int RatingCount { get; set; }
        public Dictionary<ReactionType, int> Reactions { get; set; }
        public List<Tag> Tags { get; set; }

        public CompactMediaBObj(long mediaId, string mediaName)
        {
            MediaId = mediaId;
            MediaName = mediaName;
        }

        public CompactMediaBObj(Media media)
        {
            MediaId = media.MediaId;
            MediaName = media.Name;
        }
    }
}





