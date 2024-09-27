using MovieReviewSystem.Models;
using System.Collections.Generic;
using System.Threading.Channels;

namespace MovieReviewSystem.DataLoader
{
    internal class TagDL
    {
        public static void LoadData()
        {
            List<Tag> tags = new List<Tag>
            {
                new Tag(1, "Action"),
                new Tag(2, "Adventure"),
                new Tag(3, "Comedy"),
                new Tag(4, "Drama"),
                new Tag(5, "Fantasy"),
                new Tag(6, "Horror"),
                new Tag(7, "Romance"),
                new Tag(8, "Science Fiction"),
                new Tag(9, "Thriller"),
                new Tag(10, "Animation"),
                new Tag(11, "Documentary"),
                new Tag(12, "Mystery"),
                new Tag(13, "Historical"),
                new Tag(14, "Superhero"),
                new Tag(15, "Family")

            };

            var db = MovieDatabase.GetDB();
            db.GetTagList().AddRange(tags);
        }
    }
}
