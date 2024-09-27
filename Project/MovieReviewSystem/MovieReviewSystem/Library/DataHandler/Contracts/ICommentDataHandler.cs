using MovieReviewSystem.Models;

namespace MovieReviewSystem.Library.DataHandler.Contracts
{
    interface ICommentDataHandler
    {
        public List<Comment> GetAll();
        public void Add(Comment comment);
        public void Remove(Comment comment);
    }
}
