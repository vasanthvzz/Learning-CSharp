using CommonClassLibrary;
using MediaReviewSystemLibrary.Domain;
using MediaReviewSystemLibrary.Utils;

namespace MediaReviewSystem.View
{
    public class GetReactedMediaView : IView
    {
        public void Initialize()
        {
            ConsoleManager.PrintTitle("Reacted Media");
            TriggerUseCase();
        }

        private void TriggerUseCase()
        {
            var request = new GetReactedMediaRequest(SessionManager.GetUserId());
            var callback = new GetReactedMediaPresenterCallback();
            var useCase = new GetReactedMediaUseCase(request, callback);
            useCase.Execute();
        }
    }

    public class GetReactedMediaPresenterCallback : IGetReactedMediaPresenterCallback
    {
        public void OnSuccess(ZResponse<GetReactedMediaResponse> response)
        {
            // Display the reacted Media
            GetReactedMediaResponse responseData = response.Data;
            ConsoleManager.PrintMenu("Like");
            ConsoleManager.PrintMediaCompact(responseData.LikedMedia);
            ConsoleManager.PrintMenu("Dislike");
            ConsoleManager.PrintMediaCompact(responseData.DislikedMedia);
            ConsoleManager.PrintMenu("Funny");
            ConsoleManager.PrintMediaCompact(responseData.FunnyMedia);
            ConsoleManager.PrintMenu("Sad");
            ConsoleManager.PrintMediaCompact(responseData.SadMedia);
            ConsoleManager.PrintMenu("Fear");
            ConsoleManager.PrintMediaCompact(responseData.FearMedia);
            ConsoleManager.PrintMenu("Angry");
            ConsoleManager.PrintMediaCompact(responseData.AngryMedia);
        }

        public void OnFailure(Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}
