using CommonClassLibrary;
using MediaReviewSystemLibrary.Domain;
using MediaReviewSystemLibrary.Models;
using MediaReviewSystemLibrary.Models.Entities;
using MediaReviewSystemLibrary.Utils;

namespace MediaReviewSystem.View
{
    internal class GetSingleMediaView : IView
    {
        public void Initialize()
        {
            ConsoleManager.PrintMenu("Viewing a single Media");
            GetMovieDetail();
        }

        private void GetMovieDetail()
        {
            Console.WriteLine("Enter movie id");
            long movieId = ConsoleManager.GetLong();
            GetSingleMediaRequest request = new GetSingleMediaRequest(SessionManager.GetUserId(), movieId);
            IGetSingleMediaPresenterCallback callback = new PresenterCallback();
            GetSingleMediaUseCase uc = new GetSingleMediaUseCase(request, callback);
            uc.Execute();
        }

        private class PresenterCallback : IGetSingleMediaPresenterCallback
        {
            public void OnSuccess(ZResponse<GetSingleMediaResponse> response)
            {
                ConsoleManager.PrintMediaCompact(response.Data.Media);
                List<MediaReviewBObj> reviews = response.Data.Reviews;
                foreach (MediaReviewBObj review in reviews)
                {
                    ConsoleManager.Print(review);
                }
                new ManageMediaView(response.Data.UserMedia).Initialize();
            }

            public void OnFailure(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
