using MediaReviewSystemLibrary.Models.Entities;
using MediaReviewSystem.Database;

namespace MediaReviewSystemLibrary.DataLoader
{
    public class MediaDL
    {
        public static void Initialize()
        {
            LoadData();
            Console.WriteLine("Media data loaded");
        }

        private static void LoadData()
        {
            MediaDatabase _db = MediaDatabase.GetDb();
            List<Media> mediaList = new List<Media>
            {

                new Media(1, "The Great Adventure", "Follow a group of explorers as they embark on an epic journey across the globe, facing natural disasters, wild animals, and personal challenges. This visually stunning movie captures the beauty of the world while telling a gripping story of survival and self-discovery.", MediaType.MOVIE, new   (2021, 5, 21)),

                new Media(2, "Mystery of the Night", "Set in a small, mysterious town, this thrilling series follows a group of detectives as they uncover secrets hidden deep within the town's history. Every episode presents a new twist that keeps the audience on edge as the mystery unfolds.", MediaType.MOVIE, new DateOnly(2020, 11, 10)),

                new Media(3, "Nature's Wonders", "This breathtaking documentary takes viewers on a journey through some of the most remote and beautiful locations on Earth, showcasing the extraordinary beauty and complexity of nature. From majestic mountains to lush forests, witness the wonders of the natural world.", MediaType.MOVIE, new    DateOnly(2019, 3, 15)),

                new Media(4, "Short Stories", "A unique collection of short films, each telling a different tale across various genres, from drama to comedy to suspense. These films offer insightful snapshots of the human experience, blending powerful storytelling with innovative cinematography.", MediaType.SHORT_FLIM, new        DateOnly(2022, 7, 30)),

                new Media(5, "Space Odyssey", "A visually spectacular exploration of the universe, this movie delves into the unknown realms of outer space, examining the possibilities of life beyond Earth and humanity’s future among the stars. It features cutting-edge science and philosophical reflections on the cosmos.", MediaType.MOVIE, new DateOnly(2023, 1, 5)),

                new Media(6, "Haunted House", "This spine-chilling horror series follows a group of friends who find themselves trapped in a haunted house. As they attempt to escape, they encounter terrifying supernatural forces, leading to unexpected revelations about the house's dark past.", MediaType.WEB_SERIES, new DateOnly(2021, 10, 31)),

                new Media(7, "Wildlife Safari", "Join expert naturalists as they venture deep into the wild to document the behavior and habitats of the world’s most fascinating creatures. From lions on the savanna to elephants in the jungle, this documentary provides a front-row seat to wildlife conservation efforts.", MediaType.DOCUMENTARY, new DateOnly(2020, 6, 12)),

                new Media(8, "Comedy Shorts", "A hilarious collection of short films that highlight the absurdity of everyday life. From slapstick humor to witty satire, these comedy shorts promise to deliver laughs while offering a fresh take on classic comedic tropes.", MediaType.SHORT_FLIM, new DateOnly(2022, 4, 1)),

                new Media(9, "Historical Battles", "Relive the greatest battles in history through this action-packed movie. From ancient wars to modern conflicts, the film showcases the tactics, leadership, and bravery that shaped the course of human history.", MediaType.MOVIE, new DateOnly(2021, 8, 15)),

                new Media(10, "Detective Chronicles", "A gritty, suspenseful detective series that follows a hard-boiled investigator through a web of crime, corruption, and conspiracy. As he digs deeper, the lines between justice and revenge blur in this noir-inspired story.", MediaType.WEB_SERIES, new DateOnly(2020, 9, 20)),

                new Media(11, "Ocean Depths", "Dive into the mysterious and unexplored depths of the ocean in this captivating documentary. From bioluminescent creatures to giant squid, witness the wonders that live far below the surface and learn about the fragile ecosystems that thrive there.", MediaType.DOCUMENTARY, new DateOnly(2019, 12, 25)),

                new Media(12, "Drama Shorts", "A powerful anthology of short films that explore themes of love, loss, and redemption. Each story is packed with emotion, showcasing the highs and lows of human relationships through beautifully crafted narratives.", MediaType.SHORT_FLIM, new DateOnly(2022, 11, 5)),

                new Media(13, "Alien Invasion", "A thrilling sci-fi movie about humanity's first contact with extraterrestrial beings. As tensions rise between humans and aliens, the world faces the threat of an all-out interstellar war. Can peace be achieved, or is destruction inevitable?", MediaType.MOVIE, new DateOnly(2023, 2, 14)),

                new Media(14, "Fantasy World", "Step into a magical realm filled with mystical creatures, epic battles, and ancient prophecies. This fantasy series takes viewers on a journey through a world where heroes rise, and dark forces threaten the balance of power.", MediaType.WEB_SERIES, new DateOnly(2021, 3, 17)),

                new Media(15, "Mountain Climbing", "This awe-inspiring documentary follows climbers as they scale some of the world's most dangerous peaks. Battling extreme weather and treacherous terrain, these adventurers push the limits of human endurance in pursuit of the ultimate high.", MediaType.DOCUMENTARY, new DateOnly(2020, 7, 22)),

                new Media(16, "Romantic Shorts", "A heartfelt collection of short films that explore the many facets of love. From chance encounters to long-lost loves, these romantic stories are sure to stir emotions and remind us of the beauty and pain of human connection.", MediaType.SHORT_FLIM, new DateOnly(2022, 5, 10)),

                new Media(17, "War Stories", "A gritty and intense war movie that delves into the lives of soldiers on the frontlines. Through moments of bravery, sacrifice, and heartbreak, this film paints a powerful portrait of the human cost of war.", MediaType.MOVIE, new DateOnly(2021, 6, 6)),

                new Media(18, "Crime Scene", "A riveting crime series where detectives work against the clock to solve high-profile cases. The show combines forensic science, psychological profiling, and old-school detective work to deliver edge-of-your-seat suspense.", MediaType.WEB_SERIES, new DateOnly(2020, 10, 25)),

                new Media(19, "Desert Life", "Journey into the arid landscapes of the desert in this documentary that explores the plants and animals that have adapted to survive in one of the harshest environments on Earth. Discover how life thrives where you’d least expect it.", MediaType.DOCUMENTARY, new DateOnly(2019, 4, 18)),

                new Media(20, "Action Shorts", "Get your adrenaline pumping with this collection of high-octane action short films. From daring heists to explosive car chases, these shorts are packed with thrilling sequences and nail-biting moments.", MediaType.SHORT_FLIM, new DateOnly(2022, 8, 20)),

                new Media(21, "Space Exploration", "This movie takes viewers on an inspiring and realistic journey into space, exploring humanity's ongoing quest to explore the stars. From lunar missions to deep space exploration, this film highlights both the challenges and triumphs of space travel.", MediaType.MOVIE, new DateOnly(2021, 12, 1)),

                new Media(22, "Supernatural Tales", "A gripping supernatural series filled with ghostly encounters, dark rituals, and ancient curses. Each episode delves into a new mystery, as characters face forces beyond their understanding, blurring the line between reality and the supernatural.", MediaType.WEB_SERIES, new DateOnly(2020, 1, 13)),

                new Media(23, "Forest Adventures", "Explore the lush and diverse ecosystems of the world’s forests in this documentary. From towering trees to elusive wildlife, this film showcases the importance of forests in maintaining the Earth’s ecological balance.", MediaType.DOCUMENTARY, new DateOnly(2020, 3, 30)),

                new Media(24, "Thriller Shorts", "This suspenseful collection of short films will keep you on the edge of your seat. Each film presents a tightly wound plot filled with twists, turns, and surprises that culminate in jaw-dropping finales.", MediaType.SHORT_FLIM, new DateOnly(2022, 9, 25)),

                new Media(25, "Epic Saga", "A sweeping historical drama that recounts a nation's rise to power through war, intrigue, and diplomacy. Filled with larger-than-life characters and epic battles, this movie explores the complexity of leadership in times of crisis.", MediaType.MOVIE, new DateOnly(2021, 4, 10)),

                new Media(26, "Spy Network", "In this thrilling espionage series, an elite team of spies works covertly to uncover international conspiracies and prevent global catastrophes. With high-stakes missions and morally ambiguous characters, the show explores the hidden world of intelligence gathering.", MediaType.WEB_SERIES, new DateOnly(2020, 5, 5)),

                new Media(27, "Polar Regions", "Explore the frozen tundras of the polar regions and the wildlife that call these extreme environments home. This documentary provides an in-depth look at how animals like penguins, polar bears, and seals survive the brutal cold.", MediaType.DOCUMENTARY, new DateOnly(2022, 5, 4)),

                new Media(28, "Sci-Fi Shorts", "A visionary collection of short films that explore futuristic worlds, advanced technology, and the potential consequences of scientific progress. These sci-fi shorts combine imaginative storytelling with cutting-edge visual effects.", MediaType.DOCUMENTARY, new DateOnly(2022, 12, 12)),

                new Media(29, "Martial Arts", "This action-packed martial arts movie pays homage to the golden age of kung fu films. Follow a young martial artist as he seeks revenge against those who wronged his family, delivering high-energy fight sequences and stunning choreography.", MediaType.MOVIE, new DateOnly(2021, 7, 7)),

                new Media(30, "Legal Drama", "A tense and gripping legal drama series where every case reveals deeper personal and political stakes. As the courtroom battles unfold, lawyers and clients alike must grapple with their pasts and the consequences of their choices.", MediaType.WEB_SERIES, new DateOnly(2020, 2, 22)),

                new Media(31, "Jungle Expedition", "Join a team of adventurers as they venture deep into the jungle in search of lost civilizations and hidden treasures. This documentary offers a look at the untamed beauty of the world’s rainforests and the mysteries they contain.", MediaType.DOCUMENTARY, new DateOnly(2020, 11, 11)),

                new Media(32, "Horror Shorts", "A bone-chilling collection of short films that explore the darkest corners of the human psyche. Each film delivers a unique horror experience, from psychological thrills to jump scares, guaranteed to leave audiences haunted.", MediaType.SHORT_FLIM, new DateOnly(2022, 10, 31)),

                new Media(33, "Romantic Comedy", "This lighthearted romantic comedy follows the ups and downs of love in modern times, filled with charming characters, witty dialogue, and plenty of laughs. Perfect for a feel-good movie night.", MediaType.MOVIE, new DateOnly(2021, 2, 14)),

                new Media(34, "Political Intrigue", "This politically charged thriller series explores the hidden machinations of power, where politicians, lobbyists, and journalists vie for control. With fast-paced plots and complex characters, the show delves into the world of government secrets and scandal.", MediaType.WEB_SERIES, new DateOnly(2020, 6, 18)),

                new Media(35, "Underwater World", "Discover the hidden treasures of the ocean in this documentary that takes you from coral reefs to deep-sea trenches. Meet the incredible creatures that call the ocean home and learn about the conservation efforts to protect these fragile ecosystems.", MediaType.DOCUMENTARY, new DateOnly(2019, 5, 25)),

                new Media(36, "Fantasy Shorts", "This whimsical collection of fantasy short films offers a glimpse into enchanted worlds filled with magical creatures and heroic quests. Each film brings to life a different tale of adventure and wonder.", MediaType.SHORT_FLIM, new DateOnly(2022, 3, 3)),
            };
            foreach (Media media in mediaList)
            {
                _db.AddMedia(media);
            }
        }
    }
}
