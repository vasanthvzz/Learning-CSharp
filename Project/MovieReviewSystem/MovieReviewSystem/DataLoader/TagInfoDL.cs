using MovieReviewSystem.Library.DataManager;
using MovieReviewSystem.Models;
using System.Collections.Generic;

namespace MovieReviewSystem.DataLoader
{
    internal class TagInfoDL
    {
        public static void LoadData()
        {
            List<TagInfo> tagInfos = new List<TagInfo>
            {
                // Movie "The Great Adventure" (MediaId "1") with multiple tags
                new TagInfo(1, 1), // Action
                new TagInfo(2, 1), // Adventure
                new TagInfo(3, 1), // Family

                // Movie "Mystery of the Night" (MediaId "2") with multiple tags
                new TagInfo(4, 2), // Mystery
                new TagInfo(5, 2), // Thriller
                new TagInfo(6, 2),  // Drama

                // Movie "Nature's Wonders" (MediaId 3) with multiple tags
                new TagInfo(7, 3),  // Documentary
                new TagInfo(8, 3),  // Nature
                new TagInfo(9, 3),  // Educational

                // Movie "Space Odyssey" (MediaId 5) with multiple tags
                new TagInfo(10, 5), // Science Fiction
                new TagInfo(11, 5), // Adventure
                new TagInfo(12, 5), // Action

                // Movie "Haunted House" (MediaId 6) with multiple tags
                new TagInfo(13, 6), // Horror
                new TagInfo(14, 6), // Thriller
                new TagInfo(15, 6), // Supernatural

                // Movie "Comedy Shorts" (MediaId 8) with multiple tags
                new TagInfo(11, 8), // Comedy
                new TagInfo(10, 8), // Short Film
                new TagInfo(5, 8)   // Family
            };
            foreach (TagInfo tagInfo in tagInfos)
            {

                TagDataManager tagDataManager = new TagDataManager();
                tagDataManager.AddTag(tagInfo.TagId, tagInfo.MediaId);
            }
        }
    }
}
