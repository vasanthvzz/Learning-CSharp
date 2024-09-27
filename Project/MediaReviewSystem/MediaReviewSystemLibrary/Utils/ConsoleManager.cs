using MediaReviewSystem.Database;
using MediaReviewSystemLibrary.Models;
using MediaReviewSystemLibrary.Models.Entities;

namespace MediaReviewSystemLibrary.Utils
{
    public static class ConsoleManager
    {
        public static void PrintTitle(string title)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("**********************************\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\t{title}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n**********************************");
            Console.ResetColor();
            Console.WriteLine();  // Add spacing after the title
        }

        public static long GetLong()
        {
            bool isValid = false;
            long value = 0;
            while (!isValid)
            {
                isValid = long.TryParse(Console.ReadLine(), out value);
                if (!isValid)
                {
                    Console.WriteLine("Please enter a proper numeric value");
                }
            }
            return value;
        }

        public static float GetRating()
        {
            bool isValid = false;
            float value = 0;
            while (!isValid)
            {
                isValid = float.TryParse(Console.ReadLine(), out value);
                if (!isValid || value < 1 || value > 10)
                {
                    Console.WriteLine("Please enter a valid value");
                }
            }
            return value;
        }

        public static bool InvalidChoice()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have entered an invalid option!");
                Console.ResetColor();
                Console.WriteLine("Do you want to try again? (y/n)");
                string choice = Console.ReadLine()?.Trim().ToLower();

                if (choice == "y")
                {
                    return true;
                }
                else if (choice == "n")
                {
                    return false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                    Console.ResetColor();
                }
            }
        }


        public static void PrintMediaCompact(Media media)
        {
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{media.MediaId}  {media.Name}");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(media.Description);
        }

        public static void PrintMediaCompact(CompactMediaBObj media)
        {
            Console.WriteLine("\n");
            Console.Write($"{media.MediaId}  \t {media.MediaName}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\t {(media.Rating == 0 ? "" : media.Rating.ToString("F1") + "  " + media.RatingCount + " ratings")}");
            Console.ForegroundColor = ConsoleColor.Gray;
            string tagString = "(";
            foreach (Tag tag in media.Tags)
            {
                tagString += tag.TagName + "   ";
            }
            tagString += ")";
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(tagString != "()" ? $"{tagString} \n" : "");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"{media.Reactions[ReactionType.LIKE]} Likes | {media.Reactions[ReactionType.DISLIKE]} Disikes | {media.Reactions[ReactionType.FUNNY]} Funny | {media.Reactions[ReactionType.SAD]} Sad | {media.Reactions[ReactionType.ANGRY]} Angry | {media.Reactions[ReactionType.FEAR]} Angry ");
            Console.ResetColor();
            Console.WriteLine();
        }

        public static string GetPassword()
        {
            string password = "";
            while (true)
            {
                var key = Console.ReadKey(intercept: true); // Read a key without displaying it

                // Check if the key is Enter to stop the input
                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
                // Handle Backspace
                else if (key.Key == ConsoleKey.Backspace)
                {
                    if (password.Length > 0)
                    {
                        password = password.Substring(0, password.Length - 1);
                        Console.Write("\b \b"); // Remove the last '*'
                    }
                }
                // Check if the key is a printable character (alphanumeric or symbols)
                else if (char.IsLetterOrDigit(key.KeyChar) || char.IsPunctuation(key.KeyChar) || char.IsSymbol(key.KeyChar))
                {
                    password += key.KeyChar; // Add the key to password
                    Console.Write("*"); // Display '*'
                }
            }
            Console.WriteLine(); // Move to the next line after Enter is pressed
            return password;
        }


        public static void PrintMediaCompact(List<CompactMediaBObj> media)
        {
            foreach (CompactMediaBObj mediaItem in media)
            {
                PrintMediaCompact(mediaItem);
            }
        }


        public static void PrintMenu(string s)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"------\t\t {s}\t\t------");
            Console.ResetColor();
            Console.WriteLine(); // Add spacing after menu
        }

        public static void ViewEnd()
        {
            //await Task.Yield();  // Ensures that the current method is awaited after all previous async work is completed
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n Enter a key to continue...");
            Console.ResetColor();
            Console.ReadKey();  // Blocking, but this will run only after all previous async tasks complete
            Console.WriteLine();  // Add spacing after the key press
        }

        public static void Print(MediaReviewBObj mediaReview)
        {
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(mediaReview.ReviewId);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{mediaReview.UserName}  {mediaReview.Date.ToShortDateString()}");
            Console.ResetColor();
            Console.WriteLine(mediaReview.Review);
            Console.WriteLine("\n");
        }

        public static void Print(UserReviewBObj userReview)
        {
            // Set color for Review ID
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Review ID: {userReview.ReviewId}");

            // Set color for Media Name
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Media Name: {userReview.MediaName}");

            // Set color for Description (Review)
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Review:");
            Console.ForegroundColor = ConsoleColor.White; // Reset to default color for review content
            Console.WriteLine(userReview.Description);

            // Reset color to default
            Console.ResetColor();
        }

        public static void Print(UserMediaRatingBObj media)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Media ID    : ");
            Console.ResetColor();
            Console.WriteLine($"{media.MediaId}");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Media Name  : ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{media.MediaName}");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Media Rating: ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow; // Average rating

            Console.WriteLine($"{media.MediaRating:F1}/10"); // Formats rating to one decimal place
            Console.ResetColor();
            Console.WriteLine();
        }

        public static DateOnly GetDateOnly()
        {
            DateOnly date = DateOnly.MinValue;
            bool isValid = false;
            while (!isValid)
            {
                isValid = DateOnly.TryParse(Console.ReadLine(), out date);
                if (!isValid)
                {
                    Console.WriteLine("Enter a valid date. Please try again");
                }
            }
            return date;
        }

        public static int[] GetIntegers()
        {
            List<int> validTagIds = new List<int>(); // List to hold valid tag IDs
            bool validInput = false; // Flag to check for valid input

            while (!validInput)
            {
                try
                {
                    Console.Write("Enter a list of integers (tag IDs) separated by commas: ");
                    string numbers = Console.ReadLine();

                    // Split the input string by commas and parse to integers
                    validTagIds = numbers.Split(',')
                                         .Select(number => int.Parse(number.Trim()))
                                         .ToList();

                    // If parsing is successful, set validInput to true
                    validInput = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a list of integers separated by commas.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
            return validTagIds.ToArray(); // Return the valid array of integers
        }
    }
}
