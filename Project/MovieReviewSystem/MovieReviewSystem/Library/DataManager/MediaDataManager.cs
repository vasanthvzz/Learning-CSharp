using MovieReviewSystem;
using MovieReviewSystem.Library.DataHandler;
using MovieReviewSystem.Models;

public class MediaDataManager
{
    private MediaDataHandler _mediaDataHandler;

    public MediaDataManager()
    {
        _mediaDataHandler = new MediaDataHandler();
    }

    internal List<Media> GetAllMedia()
    {
        return _mediaDataHandler.GetAll();
    }

    internal void AddMedia(Media media)
    {
        _mediaDataHandler.Add(media);
    }

    internal Media GetMovieById(int movieId)
    {
        return _mediaDataHandler.GetById(movieId);
    }
}
