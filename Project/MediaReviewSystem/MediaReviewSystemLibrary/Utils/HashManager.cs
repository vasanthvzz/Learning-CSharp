using BCrypt.Net;

namespace MediaReviewSystemLibrary.Utils
{
    public static class HashManager
    {
        public static string HashPassword(string password)
        {
            return password;
            //return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
