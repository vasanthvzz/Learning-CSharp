using CommonClassLibrary;
using MediaReviewSystemLibrary.Domain;
using MediaReviewSystemLibrary.Models;
using MediaReviewSystemLibrary.Utils;

namespace MediaReviewSystem.View
{
    public class GetRatedMediaView : IView
    {
        public void Initialize()
        {
            ConsoleManager.PrintTitle("Rated Media");
            GetRatedMedia();
        }

        private void GetRatedMedia()
        {
            GetRatedMediaRequest request = new GetRatedMediaRequest(SessionManager.GetUserId());
            GetRatedMediaPresenterCallback callback = new GetRatedMediaPresenterCallback();
            GetRatedMediaUseCase useCase = new GetRatedMediaUseCase(request, callback);
            useCase.Execute();
        }
    }

    public class GetRatedMediaPresenterCallback : IGetRatedMediaPresenterCallback
    {
        public void OnSuccess(ZResponse<GetRatedMediaResponse> response)
        {
            List<UserMediaRatingBObj> ratedMedia = response.Data.RatedMedia;
            foreach (UserMediaRatingBObj media in ratedMedia)
            {
                ConsoleManager.Print(media);
            }
        }

        public void OnFailure(Exception exception)
        {
            Console.WriteLine(exception);
        }
    }
}
