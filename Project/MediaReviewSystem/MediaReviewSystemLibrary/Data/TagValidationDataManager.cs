using CommonClassLibrary;
using MediaReviewSystem.Database;
using MediaReviewSystemLibrary.Domain;
using MediaReviewSystemLibrary.Models.Entities;

namespace MediaReviewSystemLibrary.Data
{
    public class TagValidationDataManager : ITagValidationDataManager
    {
        private MediaDatabase _db;

        public TagValidationDataManager()
        {
            _db = MediaDatabase.GetDb();
        }

        public void ValidateTag(TagValidationRequest request, TagValidationUseCaseCallback callback)
        {
            try
            {
                if (_db == null)
                {
                    callback?.OnFailure(new Exception("Unable to connect to the database"));
                    return;
                }
                List<Tag> tagList = _db.GetTagList();
                List<int> tagIdList = tagList.Select(tag => tag.TagId).ToList();
                if (tagList == null)
                {
                    callback?.OnFailure(new Exception("Unable to fetch data from the database"));
                    return;
                }
                int[] givenTagList = request.TagList;
                List<int> invalidTagIds = new();
                List<int> validTagIds = new();
                foreach (int tagId in givenTagList)
                {
                    if (tagIdList.Contains(tagId))
                    {
                        validTagIds.Add(tagId);
                    }
                    else
                    {
                        invalidTagIds.Add(tagId);
                    }
                }
                TagValidationResponse response = new TagValidationResponse(validTagIds, invalidTagIds);
                ZResponse<TagValidationResponse> zResponse = new ZResponse<TagValidationResponse>(response);
                callback?.OnSuccess(zResponse);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
