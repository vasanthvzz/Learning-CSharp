
using MovieReviewSystem.Library.DataManager;
using MovieReviewSystem.Models;
using MovieReviewSystem.Views.Utilities;

namespace MovieReviewSystem.Views
{
    internal class ReactMediaView : IView
    {

        private readonly ReactionDataManager _reactionDataManager;
        private readonly MediaDataManager _mediaDataManager;

        public ReactMediaView()
        {
            _reactionDataManager = new ReactionDataManager();
            _mediaDataManager = new MediaDataManager();
        }

        public void Initialize()
        {
            Console.Clear();
            Writer.WriteMenu("React to Media ");
            GetMovieDetail();
        }

        public void GetMovieDetail()
        {
            Console.WriteLine("Enter movie id :");
            int movieId = Parser.ParseToInt();
            Media media = _mediaDataManager.GetMovieById(movieId);
            if (media == null)
            {
                Console.WriteLine("Movie not found ");
            }
            else
            {
                Writer.WriteMedia(media);
                GetMovieReaction(media);
            }
        }

        private void GetMovieReaction(Media media)
        {
            Reaction reaction = _reactionDataManager.RetrieveReaction(SessionHandler.GetUserId(), media.MediaId);
            if (reaction == null)
            {
                reaction = new Reaction(SessionHandler.GetUserId(), media.MediaId);
            }
            else
            {
                Console.WriteLine("You have already reacted to this movies as " + reaction.MediaReaction);
            }
            bool validInput = false;
            Console.WriteLine("Provide your reaction for the movie :");
            Console.WriteLine("1.Angry \n2.Like \n3.Dislike \n4.Funny \n5.Sad \n6.Fear");
            do
            {
                validInput = true;
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        reaction.MediaReaction = ReactionType.ANGRY;
                        break;
                    case "2":
                        reaction.MediaReaction = ReactionType.LIKE;
                        break;
                    case "3":
                        reaction.MediaReaction = ReactionType.DISLIKE;
                        break;
                    case "4":
                        reaction.MediaReaction = ReactionType.FUNNY;
                        break;
                    case "5":
                        reaction.MediaReaction = ReactionType.SAD;
                        break;
                    case "6":
                        reaction.MediaReaction = ReactionType.FEAR;
                        break;
                    default:
                        Console.WriteLine("Invalid option ! Try again");
                        validInput = false;
                        break;
                }
            } while (!validInput);
            _reactionDataManager.UpdateReaction(reaction);
            Console.WriteLine("Reaction have been updated successfully");
            Console.ReadKey();
        }
    }
}
