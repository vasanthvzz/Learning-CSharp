namespace MovieReviewSystem.Views.Utilities
{
    class Parser
    {
        public static int ParseToInt()
        {
            bool isParsed = false;
            int number;

            while (!isParsed)
            {
                isParsed = Int32.TryParse(Console.ReadLine(), out number);

                if (isParsed)
                {
                    return number;
                }
                Console.WriteLine("Invalid input. Please enter a numeric value.");
            }
            return 0;
        }
    }
}
