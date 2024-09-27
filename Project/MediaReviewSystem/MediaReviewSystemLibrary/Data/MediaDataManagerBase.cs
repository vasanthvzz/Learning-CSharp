using MediaReviewSystem.Database;
using MediaReviewSystemLibrary.Models;
using MediaReviewSystemLibrary.Models.Entities;

namespace MediaReviewSystemLibrary.Data
{
    public abstract class MediaDataManagerBase
    {
        public CompactMediaBObj GetCompactMedia(long mediaId)
        {
            Media media = MediaDatabase.GetDb().GetMediaList().FirstOrDefault(media => media.MediaId == mediaId);
            if (media == null)
            {
                throw new Exception("Internal error : media with media id not exist at id : " + mediaId);
            }
            return GetCompactMedia(media);
        }

        public CompactMediaBObj GetCompactMedia(Media media)
        {
            CompactMediaBObj compactMedia = new CompactMediaBObj(media);
            long mediaId = media.MediaId;

            //Getting all the rating of the Media and calculating the average
            List<UserRating> ratings = MediaDatabase.GetDb().GetUserRatingList();
            var mediaRatings = ratings.Where(rating => rating.MediaId == mediaId).ToList();
            float averageRating = mediaRatings.Any() ? mediaRatings.Average(rating => rating.Score) : 0;
            compactMedia.Rating = averageRating;
            compactMedia.RatingCount = mediaRatings.Count();

            //Getting all the reactions
            List<Reaction> reactions = MediaDatabase.GetDb().GetReactionList();
            var mediaReactions = reactions.Where(reaction => reaction.MediaId == mediaId).ToList();

            // Initialize the Reactions dictionary with all possible ReactionTypes, defaulting to 0
            compactMedia.Reactions = Enum.GetValues(typeof(ReactionType))
                .Cast<ReactionType>()
                .ToDictionary(reactionType => reactionType, reactionType => 0);

            // Group by ReactionType and count the occurrences of each type
            var groupedReactions = mediaReactions
                .GroupBy(reaction => reaction.MediaReaction)
                .Select(group => new { ReactionType = group.Key, Count = group.Count() })
                .ToList();

            // Populate the dictionary with the actual counts
            foreach (var group in groupedReactions)
            {
                compactMedia.Reactions[group.ReactionType] = group.Count;
            }

            //Fetching Tags of each movies
            List<TagInfo> tagInfos = MediaDatabase.GetDb().GetTagInfoList();
            var mediaTagInfos = tagInfos.Where(tagInfo => tagInfo.MediaId == mediaId).ToList();
            List<Tag> mediaTags = new List<Tag>();
            foreach (var mediaTagInfo in mediaTagInfos)
            {
                Tag tag = MediaDatabase.GetDb().GetTagList().FirstOrDefault(tag => tag.TagId == mediaTagInfo.TagId);
                mediaTags.Add(tag);
            }
            compactMedia.Tags = mediaTags;

            return compactMedia;
        }
    }
}
