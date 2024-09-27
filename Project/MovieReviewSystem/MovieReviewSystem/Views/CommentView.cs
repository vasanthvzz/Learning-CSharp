using MovieReviewSystem.Library.DataManager;
using MovieReviewSystem.Models;
using MovieReviewSystem.Views.Utilities;

namespace MovieReviewSystem.Views
{
    internal class CommentView : IView
    {
        private readonly ReviewDataManager _reviewDataManager;
        private readonly Media _media;
        private readonly CommentDataManager _commentDataManager;

        public CommentView(Media media)
        {
            _reviewDataManager = new ReviewDataManager();
            _media = media;
            _commentDataManager = new CommentDataManager();
        }

        public void Initialize()
        {
            Writer.WriteMenu("Comment a Review menu");
            ShowCommentMenu();

        }

        private void ShowCommentMenu()
        {
            Console.WriteLine("Enter the review id of the review");
            int reviewId = Parser.ParseToInt();
            Review review = _reviewDataManager.GetById(reviewId);
            if (review == null || review.MediaId != _media.MediaId)
            {
                Console.WriteLine("Review not found! please try again");
                return;
            }
            Console.WriteLine("Enter your comment : ");
            string description = Console.ReadLine();
            Comment comment = new Comment(SessionHandler.GetUserId(), review.MediaId, description, review.ReviewId);
            Console.WriteLine("Comment has been added successfully");
            _commentDataManager.AddComment(comment);
            Writer.ViewEnd();
        }
    }
}
