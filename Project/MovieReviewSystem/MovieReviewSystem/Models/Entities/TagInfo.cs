namespace MediaReviewSystemLibrary.Models.Entities
{
    public class TagInfo
    {
        public int TagId { get; set; }
        public int MediaId { get; set; }

        public TagInfo(int tagId, int mediaId)
        {
            TagId = tagId;
            MediaId = mediaId;
        }
    }
}
