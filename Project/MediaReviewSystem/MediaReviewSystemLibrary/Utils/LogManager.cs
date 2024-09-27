using MediaReviewSystem.Database;
using MediaReviewSystemLibrary.Models.Entities;

namespace MediaReviewSystemLibrary.Utils
{
    public static class LogManager
    {
        public static void LogAllUser()
        {
            foreach (UserDetail user in MediaDatabase.GetDb().GetUserDetails())
            {
                Console.WriteLine(user.UserId + "  " + user.UserName);
            }
        }
    }
}
