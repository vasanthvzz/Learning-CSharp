using MovieReviewSystem.DataLoader;
using MovieReviewSystem.Library.DataManager;
using MovieReviewSystem.Models;
using MovieReviewSystem.Views.Utilities;

namespace MovieReviewSystem.Views
{
    internal class SingleMediaView : IView
    {
        private MediaDataManager _mediaDataManager;
        private ReviewDataManager _reviewDataManager;
        private UserDataManager _userDataManager;
        private ReactionDataManager _reactionDataManager;
        private UserRatingDataManager _userRatingDataManager;
        private CommentDataManager _commentDataManager;
        private Media media;

        public SingleMediaView()
        {
            _mediaDataManager = new MediaDataManager();
            _reviewDataManager = new ReviewDataManager();
            _userDataManager = new UserDataManager();
            _reactionDataManager = new ReactionDataManager();
            _userRatingDataManager = new UserRatingDataManager();
            _commentDataManager = new CommentDataManager();
        }

        public void Initialize()
        {
            Console.Clear();
            Writer.WriteMenu("View a movie (add comment )");
            Console.WriteLine("Enter movie id :");
            int movieId = Parser.ParseToInt();
            Media tempMedia = _mediaDataManager.GetMovieById(movieId);
            if (tempMedia == null)
            {
                Console.WriteLine("Movie not found ");
            }
            else
            {
                media = tempMedia;
                Writer.WriteMedia(media);
                ShowReactionSection();
                ShowReviewSection();
                RedirectCommentView();
            }
        }

        private void RedirectCommentView()
        {
            Console.WriteLine("Do you want to write a comment ?(press y to write)");
            string choice = Console.ReadLine().Trim().ToLower();
            if (choice == "y")
            {
                IView view = new CommentView(media);
                view.Initialize();
            }
        }



        public void ShowReviewSection()
        {
            Writer.WriteMenu("Reviews : ");
            List<Review> reviews = _reviewDataManager.GetByMediaId(media.MediaId);
            var sortedReviews = reviews.OrderByDescending(r => r.Datetime).ToList();
            foreach (Review review in sortedReviews)
            {
                string userName = _userDataManager.GetUserName(review.UserId);
                Writer.WriteReview(review, userName);
                GetCommentSection(review.ReviewId);
            }
        }

        public void GetCommentSection(int reviewId)
        {
            List<Comment> commentList = _commentDataManager.GetCommentByReviewId(reviewId);
            var sortedReviews = commentList.OrderByDescending(r => r.Datetime).ToList();
            foreach (Comment comment in sortedReviews)
            {
                Writer.WriteComment(comment);
            }
        }

        public void ShowReactionSection()
        {
            Console.Write(_reactionDataManager.ReactionCount(media.MediaId, ReactionType.LIKE) + " - like \t ");
            Console.Write(_reactionDataManager.ReactionCount(media.MediaId, ReactionType.DISLIKE) + " - dislike \t ");
            Console.Write(_reactionDataManager.ReactionCount(media.MediaId, ReactionType.FUNNY) + " - funny \t ");
            Console.Write(_reactionDataManager.ReactionCount(media.MediaId, ReactionType.ANGRY) + " - Angry \t ");
            Console.Write(_reactionDataManager.ReactionCount(media.MediaId, ReactionType.FEAR) + " - fear \t ");
            Console.Write(_reactionDataManager.ReactionCount(media.MediaId, ReactionType.SAD) + " - sad \t ");
            Console.WriteLine();
        }
    }
}
