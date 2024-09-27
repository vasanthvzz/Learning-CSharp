using MovieReviewSystem.Library.DataHandler.Contracts;
using MovieReviewSystem.Models;

namespace MovieReviewSystem.Library.DataHandler
{
    internal class CommentDataHandler : ICommentDataHandler
    {
        private MovieDatabase _database;
        public CommentDataHandler()
        {
            _database = MovieDatabase.GetDB();
        }

        public List<Comment> GetAll()
        {
            return _database.GetCommentList();
        }

        public void Add(Comment comment)
        {
            _database.AddComment(comment);
        }

        public void Remove(Comment comment)
        {
            _database.RemoveComment(comment);
        }
    }
}
