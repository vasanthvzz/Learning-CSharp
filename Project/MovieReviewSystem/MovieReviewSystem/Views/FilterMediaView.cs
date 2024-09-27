using MovieReviewSystem.Library.DataHandler;
using MovieReviewSystem.Library.DataManager;
using MovieReviewSystem.Models;
using MovieReviewSystem.Models.Wrapper;
using MovieReviewSystem.Views.Utilities;

namespace MovieReviewSystem.Views
{
    internal class FilterMediaView : IView
    {
        private readonly TagDataManager _tagDataManager;
        private readonly ActorDataManager _actorDataManager;
        private readonly MediaDataHandler _mediaDataHandler;

        public FilterMediaView()
        {
            _actorDataManager = new ActorDataManager();
            _tagDataManager = new TagDataManager();
            _mediaDataHandler = new MediaDataHandler();
        }

        public void Initialize()
        {
            Console.Clear();
            Writer.WriteMenu("Filter / Search Menu");
            ShowMenu();
        }

        private void ShowMenu()
        {
            Console.WriteLine("1.Search media by name.");
            Console.WriteLine("2.Filter media by tags");
            Console.WriteLine("3.Filter media by actors");
            Console.WriteLine("Enter your choice ");
            string choice = Console.ReadLine();
            RedirectChoice(choice);
        }

        private void RedirectChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    SearchByName();
                    break;
                case "2":
                    FilterByTags();
                    break;
                case "3":
                    FilterByActors();
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }

        private void FilterByActors()
        {
            Writer.PrintAllActors();
            Console.WriteLine("Please enter the actor id you want to view");
            int actorId = Parser.ParseToInt();
            List<Media> mediaList = new List<Media>();
            mediaList.AddRange(_actorDataManager.GetMedia(actorId));
            foreach (Media media in mediaList.Distinct())
            {
                Writer.WriteMedia(media);
            }
            Console.ReadKey();
        }

        private void FilterByTags()
        {
            Writer.PrintAllTag();
            Console.WriteLine("Please enter the tag id you want to view");
            int tagId = Parser.ParseToInt();
            List<Media> mediaList = new List<Media>();
            mediaList.AddRange(_tagDataManager.GetMedia(tagId));
            foreach (Media media in mediaList.Distinct())
            {
                Writer.WriteMedia(media);
            }
            Console.ReadKey();
        }

        private void SearchByName()
        {
            Console.WriteLine("Enter the name: ");
            string searchTerm = Console.ReadLine().ToLower();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                Console.WriteLine("Search term cannot be empty.");
                return;
            }

            // Fetch all media and wrap them in MediaDetails
            List<Media> mediaList = _mediaDataHandler.GetAll();
            List<MediaDetails> mediaDetails = mediaList
                .Select(media => MediaWrapper.WrapToMediaDetail(media))
                .ToList();
            bool found = false;
            foreach (MediaDetails mediaDetail in mediaDetails)
            {
                if (IsPartialMatch(mediaDetail, searchTerm))
                {
                    found = true;
                    Console.WriteLine($"Found matching media: {mediaDetail.Name} - {mediaDetail.MediaId}");
                }
            }
            if (!found)
            {
                Console.WriteLine("No matching media founded !");
            }
            Console.ReadKey();
            // If no matching media found
        }

        private bool IsPartialMatch(MediaDetails mediaDetails, string input)
        {
            string lowerInput = input.ToLower();

            // Check if any of the string properties contain the input string partially
            return mediaDetails.Name.ToLower().Contains(lowerInput) ||
                   mediaDetails.Description.ToLower().Contains(lowerInput) ||
                   mediaDetails.Tags.Any(tag => tag.ToLower().Contains(lowerInput)) ||
                   mediaDetails.Actors.Any(actor => actor.ToLower().Split(' ').Contains(lowerInput));
        }
    }
}
