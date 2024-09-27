using MediaReviewSystemLibrary.Models.Entities;

namespace MediaReviewSystemLibrary.Utils
{
    public static class SessionManager
    {
        private static UserDetail? user;

        public static void SetUser(UserDetail currentUser)
        {
            user = currentUser;
            Console.WriteLine(user.UserId);
        }

        public static UserDetail GetUser() => user;

        public static long GetUserId()
        {
            return user.UserId;
        }

        public static void Clear()
        {
            user = null;
        }
    }
}
