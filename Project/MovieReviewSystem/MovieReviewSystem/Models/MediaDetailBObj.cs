namespace MediaReviewSystemLibrary.Models
{
    public class MediaDetails
    {
        public MediaDetails(int mediaId, string name, string description, MediaType contentType, DateTime releaseDate)
        {
            MediaId = mediaId;
            Name = name;
            Description = description;
            MediaType = contentType;
            ReleaseDate = releaseDate;
        }

        public int MediaId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public MediaType MediaType { get; set; }
        public float Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<string> Tags { get; set; }    // List of Tag objects representing media-tag relationships
        public List<string> Actors { get; set; } // List of actors
    }
}
