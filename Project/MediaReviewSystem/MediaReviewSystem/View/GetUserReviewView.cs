using CommonClassLibrary;
using MediaReviewSystemLibrary.Domain;
using MediaReviewSystemLibrary.Models;
using MediaReviewSystemLibrary.Utils;

namespace MediaReviewSystem.View
{
    public class GetUserReviewView : IView
    {
        public void Initialize()
        {
            ConsoleManager.PrintTitle("My Reviews");
            GetUserReviews();
        }

        private void GetUserReviews()
        {
            GetUserReviewRequest request = new GetUserReviewRequest(SessionManager.GetUserId());
            GetUserReviewPresenterCallback callback = new GetUserReviewPresenterCallback();
            GetUserReviewUseCase useCase = new GetUserReviewUseCase(request, callback);
            useCase.Execute();
        }
    }

    public class GetUserReviewPresenterCallback : IGetUserReviewPresenterCallback
    {
        public void OnSuccess(ZResponse<GetUserReviewResponse> response)
        {
            List<UserReviewBObj> userReviews = response.Data.UserReviews;
            foreach (UserReviewBObj userReview in userReviews)
            {
                ConsoleManager.Print(userReview);
            }
        }

        public void OnFailure(Exception exception)
        {
            Console.WriteLine(exception);
        }
    }
}
