namespace MovieReviewSystem
{
    static class SessionHandler
    {
        private static User user;

        public static void SetUser(User currentUser)
        {
            user = currentUser;
        }

        public static User GetUser()
        {
            return user;
        }

        public static int GetUserId()
        {
            return user.UserId;
        }
    }
}
