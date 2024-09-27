namespace MediaReviewSystemLibrary.Models.Entities
{
    public class TagInfo
    {
        public int TagId { get; set; }
        public long MediaId { get; set; }

        public TagInfo(int tagId, long mediaId)
        {
            TagId = tagId;
            MediaId = mediaId;
        }
    }
}
