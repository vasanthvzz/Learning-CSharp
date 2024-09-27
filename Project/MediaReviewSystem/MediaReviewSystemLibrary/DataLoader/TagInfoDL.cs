using MediaReviewSystem.Database;
using MediaReviewSystemLibrary.Models.Entities;

internal class TagInfoDL
{
    public static void Initialize()
    {
        LoadData();
        Console.WriteLine("Tags info loaded");
    }

    private static void LoadData()
    {
        List<TagInfo> tagInfos = new List<TagInfo>
        {
            // Movie "The Great Adventure" (MediaId 1)
            new TagInfo(1, 1), // Action
            new TagInfo(2, 1), // Adventure
            new TagInfo(3, 1), // Family

            // Movie "Mystery of the Night" (MediaId 2)
            new TagInfo(4, 2), // Mystery
            new TagInfo(5, 2), // Thriller
            new TagInfo(6, 2), // Drama

            // Movie "Nature's Wonders" (MediaId 3)
            new TagInfo(7, 3), // Documentary
            new TagInfo(8, 3), // Nature
            new TagInfo(9, 3), // Educational

            // Movie "Space Odyssey" (MediaId 4)
            new TagInfo(10, 4), // Science Fiction
            new TagInfo(11, 4), // Adventure
            new TagInfo(12, 4), // Action

            // Movie "Haunted House" (MediaId 5)
            new TagInfo(13, 5), // Horror
            new TagInfo(5, 5),  // Thriller
            new TagInfo(15, 5), // Supernatural

            // Movie "Comedy Shorts" (MediaId 6)
            new TagInfo(11, 6), // Comedy
            new TagInfo(10, 6), // Short Film
            new TagInfo(3, 6),  // Family

            // Movie "Beyond the Stars" (MediaId 7)
            new TagInfo(10, 7), // Science Fiction
            new TagInfo(12, 7), // Action
            new TagInfo(14, 7), // Fantasy

            // Movie "Silent Screams" (MediaId 8)
            new TagInfo(13, 8), // Horror
            new TagInfo(15, 8), // Supernatural
            new TagInfo(4, 8),  // Mystery

            // Movie "Romantic Getaway" (MediaId 9)
            new TagInfo(6, 9),  // Drama
            new TagInfo(3, 9),  // Family
            new TagInfo(14, 9), // Fantasy

            // Movie "The Last Detective" (MediaId 10)
            new TagInfo(4, 10), // Mystery
            new TagInfo(5, 10), // Thriller
            new TagInfo(6, 10), // Drama

            // Movie "Underwater Dreams" (MediaId 11)
            new TagInfo(8, 11), // Nature
            new TagInfo(7, 11), // Documentary
            new TagInfo(9, 11), // Educational

            // Movie "Alien Invasion" (MediaId 12)
            new TagInfo(10, 12), // Science Fiction
            new TagInfo(12, 12), // Action
            new TagInfo(14, 12), // Fantasy

            // Movie "War Heroes" (MediaId 13)
            new TagInfo(1, 13), // Action
            new TagInfo(2, 13), // Adventure
            new TagInfo(6, 13), // Drama

            // Movie "Galaxy Quest" (MediaId 14)
            new TagInfo(10, 14), // Science Fiction
            new TagInfo(12, 14), // Action
            new TagInfo(11, 14), // Adventure

            // Movie "Pirate's Life" (MediaId 15)
            new TagInfo(2, 15),  // Adventure
            new TagInfo(5, 15),  // Thriller
            new TagInfo(1, 15),  // Action

            // Movie "Magic Realm" (MediaId 16)
            new TagInfo(14, 16), // Fantasy
            new TagInfo(15, 16), // Supernatural
            new TagInfo(4, 16),  // Mystery

            // Movie "City Lights" (MediaId 17)
            new TagInfo(3, 17),  // Family
            new TagInfo(11, 17), // Comedy
            new TagInfo(6, 17),  // Drama

            // Movie "Journey to the West" (MediaId 18)
            new TagInfo(2, 18),  // Adventure
            new TagInfo(12, 18), // Action
            new TagInfo(14, 18), // Fantasy

            // Movie "Desert Storm" (MediaId 19)
            new TagInfo(1, 19),  // Action
            new TagInfo(2, 19),  // Adventure
            new TagInfo(5, 19),  // Thriller

            // Movie "Lost in the Jungle" (MediaId 20)
            new TagInfo(8, 20),  // Nature
            new TagInfo(7, 20),  // Documentary
            new TagInfo(9, 20),  // Educational

            // Movie "Fictional World" (MediaId 21)
            new TagInfo(14, 21), // Fantasy
            new TagInfo(10, 21), // Science Fiction
            new TagInfo(12, 21), // Action

            // Movie "The Lone Ranger" (MediaId 22)
            new TagInfo(2, 22),  // Adventure
            new TagInfo(1, 22),  // Action
            new TagInfo(6, 22),  // Drama

            // Movie "Haunted Memories" (MediaId 23)
            new TagInfo(13, 23), // Horror
            new TagInfo(15, 23), // Supernatural
            new TagInfo(4, 23),  // Mystery

            // Movie "Virtual Reality" (MediaId 24)
            new TagInfo(10, 24), // Science Fiction
            new TagInfo(12, 24), // Action
            new TagInfo(11, 24), // Adventure

            // Movie "Time Traveler" (MediaId 25)
            new TagInfo(14, 25), // Fantasy
            new TagInfo(10, 25), // Science Fiction
            new TagInfo(4, 25),  // Mystery

            // Movie "Moonlight Shadows" (MediaId 26)
            new TagInfo(5, 26),  // Thriller
            new TagInfo(6, 26),  // Drama
            new TagInfo(13, 26), // Horror

            // Movie "The Hidden City" (MediaId 27)
            new TagInfo(2, 27),  // Adventure
            new TagInfo(1, 27),  // Action
            new TagInfo(5, 27),  // Thriller

            // Movie "World at War" (MediaId 28)
            new TagInfo(1, 28),  // Action
            new TagInfo(6, 28),  // Drama
            new TagInfo(12, 28), // Action

            // Movie "Tales of Old" (MediaId 29)
            new TagInfo(14, 29), // Fantasy
            new TagInfo(4, 29),  // Mystery
            new TagInfo(5, 29),  // Thriller

            // Movie "The Mountain Pass" (MediaId 30)
            new TagInfo(2, 30),  // Adventure
            new TagInfo(8, 30),  // Nature
            new TagInfo(7, 30),  // Documentary

            // Movie "Lights Out" (MediaId 31)
            new TagInfo(13, 31), // Horror
            new TagInfo(15, 31), // Supernatural
            new TagInfo(5, 31),  // Thriller

            // Movie "Planet Earth" (MediaId 32)
            new TagInfo(7, 32),  // Documentary
            new TagInfo(9, 32),  // Educational
            new TagInfo(8, 32),  // Nature

            // Movie "Superhero Squad" (MediaId 33)
            new TagInfo(1, 33),  // Action
            new TagInfo(12, 33), // Action
            new TagInfo(11, 33), // Adventure

            // Movie "High School Drama" (MediaId 34)
            new TagInfo(6, 34),  // Drama
            new TagInfo(11, 34), // Comedy
            new TagInfo(3, 34),  // Family

            // Movie "Space Explorers" (MediaId 35)
            new TagInfo(10, 35), // Science Fiction
            new TagInfo(12, 35), // Action
            new TagInfo(2, 35),  // Adventure

            // Movie "Ghostly Encounters" (MediaId 36)
            new TagInfo(13, 36), // Horror
            new TagInfo(15, 36), // Supernatural
            new TagInfo(4, 36),  // Mystery
        };

        foreach (TagInfo tagInfo in tagInfos)
        {
            MediaDatabase.GetDb().AddTagInfo(new TagInfo(tagInfo.TagId, tagInfo.MediaId));
        }
    }
}
