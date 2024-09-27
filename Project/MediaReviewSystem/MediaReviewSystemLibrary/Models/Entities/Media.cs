namespace MediaReviewSystemLibrary.Models.Entities
{
    public class Media
    {
        public long MediaId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public MediaType MediaType { get; set; }
        public DateOnly ReleaseDate { get; set; }

        public Media(long mediaId, string name, string description, MediaType contentType, DateOnly releaseDate)
        {
            MediaId = mediaId;
            Name = name;
            Description = description;
            MediaType = contentType;
            ReleaseDate = releaseDate;
        }
    }
}
