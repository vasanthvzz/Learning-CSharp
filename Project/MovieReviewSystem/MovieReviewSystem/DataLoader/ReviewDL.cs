using MovieReviewSystem.Models;

namespace MovieReviewSystem.DataLoader
{
    internal class ReviewDL
    {
        public static void LoadData()
        {
            var db = MovieDatabase.GetDB();
            List<Review> reviews = new List<Review>();
            Random rand = new Random();

            // Fetch all media from the database
            List<Media> allMedia = db.GetMediaList();

            // Expanded review templates for more variety
            string[] positiveReviewTemplates = new string[]
            {
                "An absolutely stunning film! The cinematography was breathtaking, and the acting performances were outstanding. This is a movie I will watch again and again.",
                "This film exceeded all my expectations. From the script to the special effects, everything was spot on. A masterpiece of modern cinema!",
                "A brilliant movie with an engaging story and top-notch performances. Every scene was beautifully shot, and the soundtrack was perfect. Highly recommended!",
                "A visual and emotional masterpiece! The storytelling was flawless, and the characters felt real. One of the best movies I’ve seen in a long time.",
                "Such a powerful film! It made me laugh, cry, and think deeply. The direction was superb, and the plot twists kept me hooked until the very end."
            };

            string[] neutralReviewTemplates = new string[]
            {
                "It was an okay movie, but I felt it lacked something special. The plot was predictable, and the characters didn’t really stand out. Worth a watch, though.",
                "Not bad, but not great either. There were a few memorable moments, but overall it felt a little underwhelming. I expected more from the cast and director.",
                "The movie had its moments, but it was pretty standard. The plot was a bit slow, and it didn’t hold my attention the whole time. Still, it had a decent ending.",
                "An average movie with a decent premise, but it never fully delivered. It’s the kind of movie you watch once and then forget about. Nothing too memorable.",
                "A fairly standard film. It wasn’t bad, but it also didn’t do anything new or exciting. The performances were decent, but the plot could have been more original."
            };

            string[] negativeReviewTemplates = new string[]
            {
                "I was really disappointed by this movie. The plot made no sense, the characters were flat, and the pacing was all over the place. I wouldn’t recommend it.",
                "What a waste of time! This movie felt like a huge missed opportunity. The acting was stiff, the dialogue was cringe-worthy, and the plot went nowhere.",
                "I couldn’t stay engaged with this movie. The story was confusing, and I didn’t care about any of the characters. It felt like it dragged on forever.",
                "One of the worst movies I’ve seen recently. The plot was a complete mess, and the characters were poorly written. I struggled to finish it.",
                "I had high hopes for this movie, but it was a big letdown. The pacing was slow, and the story didn’t go anywhere. Definitely not worth watching."
            };

            // Generate fewer but detailed reviews for each media (10 reviews per media)
            for (int userId = 1; userId <= 10; userId++) // Limiting to 10 users per media
            {
                int currentUserId = userId;

                foreach (var media in allMedia)
                {
                    int mediaId = media.MediaId;

                    // Randomly select a review template from positive, neutral, or negative
                    string selectedReview;
                    int reviewType = rand.Next(3); // 0 for positive, 1 for neutral, 2 for negative

                    if (reviewType == 0)
                        selectedReview = positiveReviewTemplates[rand.Next(positiveReviewTemplates.Length)];
                    else if (reviewType == 1)
                        selectedReview = neutralReviewTemplates[rand.Next(neutralReviewTemplates.Length)];
                    else
                        selectedReview = negativeReviewTemplates[rand.Next(negativeReviewTemplates.Length)];

                    // Create a new Review object with the selected template
                    Review review = new Review(currentUserId, mediaId, selectedReview)
                    {
                        Datetime = DateTime.Now.AddMinutes(-rand.Next(0, 10000)) // Random datetime adjustment
                    };

                    reviews.Add(review);
                }
            }

            // Add all the generated reviews to the database
            db.GetReviewList().AddRange(reviews);
        }
    }
}
