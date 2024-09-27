using CommonClassLibrary;
using MediaReviewSystemLibrary.Domain;
using MediaReviewSystemLibrary.Models;
using MediaReviewSystemLibrary.Models.Entities;
using MediaReviewSystemLibrary.Utils;

namespace MediaReviewSystem.View
{
    class GetAllMediaView : IView
    {
        public void Initialize()
        {
            ConsoleManager.PrintMenu("Viewing all media");
            GetAllMedia();
        }

        public void GetAllMedia()
        {
            GetAllMediaRequest req = new GetAllMediaRequest();
            IGetAllMediaPresenterCallback res = new GetAllMediaPresentCallback();
            GetAllMediaUseCase uc = new GetAllMediaUseCase(req, res);
            uc.Execute();
        }

        private class GetAllMediaPresentCallback : IGetAllMediaPresenterCallback
        {
            public GetAllMediaPresentCallback() { }
            public void OnSuccess(ZResponse<GetAllMediaResponse> response)
            {
                GetAllMediaResponse res = response.Data;
                foreach (CompactMediaBObj media in res.MediaList)
                {
                    ConsoleManager.PrintMediaCompact(media);
                }
                ConsoleManager.PrintMenu("Do you want to select a media ? 'y' for yes or press any key ");
                string choice = Console.ReadLine();
                if (choice == "y")
                {
                    new GetSingleMediaView().Initialize();
                }

            }
            public void OnFailure(Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }
    }
}
