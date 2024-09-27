using MovieReviewSystem.Models;

namespace MovieReviewSystem.Library.DataManager
{
    internal class CommentDataManager
    {
        private readonly MovieDatabase _database;
        public CommentDataManager()
        {
            _database = MovieDatabase.GetDB();
        }

        public void AddComment(Comment comment)
        {
            _database.AddComment(comment);
        }

        public List<Comment> GetAll()
        {
            return _database.GetCommentList();
        }

        public List<Comment> GetCommentByReviewId(int reviewId)
        {
            return _database.GetCommentList().Where(comment => comment.ParentReviewId == reviewId).ToList();
        }

        public Comment GetById(int id)
        {
            return _database.GetCommentList().FirstOrDefault(comment => comment.CommentId == id);
        }
    }
}
