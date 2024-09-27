namespace MediaReviewSystemLibrary.Models.Entities
{
    public class UserPasswordMapper
    {
        public long UserId { get; set; }
        public string Password { get; set; }

        public UserPasswordMapper(string password)
        {
            // Use Unix time in seconds or milliseconds without risk of overflow
            UserId = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            Password = password;
        }
    }

}

