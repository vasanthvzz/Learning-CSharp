namespace MediaReviewSystem.Models
{
    public class Media
    {
        public Media(int mediaId, string name, string description, MediaType contentType, DateTime releaseDate)
        {
            this.MediaId = mediaId;
            this.Name = name;
            this.Description = description;
            this.MediaType = contentType;
            this.ReleaseDate = releaseDate;
        }

        public int MediaId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public MediaType MediaType { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
