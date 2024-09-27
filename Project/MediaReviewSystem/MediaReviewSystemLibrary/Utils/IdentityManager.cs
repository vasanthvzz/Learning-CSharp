namespace MediaReviewSystemLibrary.Utils
{
    public static class IdentityManager
    {
        public static long GenerateUniqueId()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }
    }
}
