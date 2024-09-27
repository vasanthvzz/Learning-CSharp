using CommonClassLibrary;
using MediaReviewSystemLibrary.Domain;
using MediaReviewSystemLibrary.Utils;

namespace MediaReviewSystem.View
{
    public class GetPersonalMediaView : IView
    {
        public void Initialize()
        {
            ConsoleManager.PrintMenu("Personal Movie List ");
            ShowPersonalMedia();
        }

        private void ShowPersonalMedia()
        {
            GetPersonalMediaRequest req = new GetPersonalMediaRequest(SessionManager.GetUserId());
            GetPersonalMediaPresenterCallback res = new GetPersonalMediaPresenterCallback();
            GetPersonalMediaUseCase uc = new GetPersonalMediaUseCase(req, res);
            uc.Execute();
        }

        private class GetPersonalMediaPresenterCallback : IGetPersonalMediaPresenterCallback
        {
            public GetPersonalMediaPresenterCallback()
            {
            }

            public void OnSuccess(ZResponse<GetPersonalMediaResponse> response)
            {
                ConsoleManager.PrintMenu("Favourites Movies");
                ConsoleManager.PrintMediaCompact(response.Data.FavouriteMedia);

                ConsoleManager.PrintMenu("Movies in yet to Watch");
                ConsoleManager.PrintMediaCompact(response.Data.YetToWatchMedia);

                ConsoleManager.PrintMenu("Movies in Watched list");
                ConsoleManager.PrintMediaCompact(response.Data.HasWatchedMedia);
            }

            public void OnFailure(Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}
