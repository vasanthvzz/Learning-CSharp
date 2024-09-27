using CommonClassLibrary;
using MediaReviewSystemLibrary.Domain;
using MediaReviewSystemLibrary.Models;
using MediaReviewSystemLibrary.Utils;

namespace MediaReviewSystem.View
{
    public class ManageMediaView : IView
    {
        public UserMediaBObj Media { get; set; }

        public ManageMediaView(UserMediaBObj media)
        {
            Media = media;
        }

        public void Initialize()
        {
            ConsoleManager.PrintMenu("Manage Media ");
            ShowMenu();

        }

        private void ShowMenu()
        {
            Console.WriteLine("1. Add a review");
            Console.WriteLine("2. " + (Media.IsFavourite ? "Remove from favourite " : "Add to favourite"));
            Console.WriteLine("3. " + (Media.HasWatched ? "Remove from watched movie list" : "Add to watched movie list"));
            Console.WriteLine("4. " + (Media.IsYetToWatch ? "Remove from yet to watch list" : "Add to yet to watch list"));
            if (Media.UserRating == 0)
            {
                Console.WriteLine("5. Add rating to the movie ");
            }
            else
            {
                Console.WriteLine("5. Change Media rating (You have provided this movie rating as " + Media.UserRating + " )");
            }
            if (Media.Reaction.Equals(ReactionType.NEUTRAL))
            {
                Console.WriteLine("6. Add reaction to the movie");
            }
            else
            {
                Console.WriteLine("6. Change movie reaction (You have reacted this movie with : " + Media.Reaction.ToString() + " )");
            }
            Console.WriteLine("0. To Go back");
            RedirectChoice();
        }

        private void RedirectChoice()
        {

            Console.WriteLine("Enter your choice");
            bool update = true;
            string choice = Console.ReadLine();
            if (choice == "0")
            {
                return;
            }
            switch (choice)
            {
                case "1":
                    {
                        UserReviewMenu();
                        break;
                    }
                case "2":
                    {
                        Media.IsFavourite = !Media.IsFavourite;
                        break;
                    }
                case "3":
                    {
                        Media.HasWatched = !Media.HasWatched;
                        break;
                    }
                case "4":
                    {
                        Media.IsYetToWatch = !Media.IsYetToWatch;
                        break;
                    }
                case "5":
                    {
                        UserRatingMenu();
                        break;
                    }
                case "6":
                    {
                        UserReactionMenu();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid option");
                        update = false;
                        break;
                    }
            }
            if (update)
            {
                ProcessMediaUpdate();
            }
            Initialize();
        }

        private void UserRatingMenu()
        {
            Console.WriteLine("Enter your rating(please enter a range between 1 to 10)");
            float rating = ConsoleManager.GetRating();
            Media.UserRating = rating;
        }

        private void UserReactionMenu()
        {
            ConsoleManager.PrintMenu("Add reaction menu");
            Console.WriteLine("1. Like \n2. Dislike \n3. Funny \n4. Sad \n5. Angry \n6. Fear \n7. To remove reaction");
            bool isValid = false;
            int value = 0;
            while (!isValid)
            {
                isValid = int.TryParse(Console.ReadLine(), out value);
                isValid = isValid && value >= 1 && value <= 7;
                if (!isValid)
                {
                    Console.WriteLine("Please enter a proper numeric value");
                }
            }
            ReactionType selectedReaction = (ReactionType)(value);
            Media.Reaction = selectedReaction;
        }

        private void UserReviewMenu()
        {
            ConsoleManager.PrintMenu("Review menu");
            Console.WriteLine("Enter your review for the movie");
            string review = Console.ReadLine();
            ProcessMediaUpdate(review);
        }

        private void ProcessMediaUpdate(string review = null)
        {
            PresenterCallback callback = new PresenterCallback(this);
            ManageMediaRequest request = new ManageMediaRequest(SessionManager.GetUserId(), review, Media);
            ManageMediaUseCase usecase = new ManageMediaUseCase(request, callback);
            usecase.Execute();
        }


        private class PresenterCallback : IManageMediaPresenterCallback
        {
            private ManageMediaView _presenter;

            public PresenterCallback(ManageMediaView manageMediaView)
            {
                _presenter = manageMediaView;
            }

            public void OnSuccess(ZResponse<ManageMediaResponse> response)
            {
                Console.WriteLine("Updated succesfully");
                _presenter.Media = response.Data.UserMedia;
            }

            public void OnFailure(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
