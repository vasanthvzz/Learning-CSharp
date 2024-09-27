using MediaReviewSystem.Database;
using MediaReviewSystemLibrary.Models.Entities;

namespace MediaReviewSystemLibrary.Utils
{
    public static class AuthManager
    {
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return password == hashedPassword;
            //return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        public static bool IsAdmin(long userId)
        {
            IMediaDatabase db = MediaDatabase.GetDb();
            Admin admin = db.GetAdminList().FirstOrDefault(admin => admin.UserId == userId);
            return admin != null;
        }
    }
}
