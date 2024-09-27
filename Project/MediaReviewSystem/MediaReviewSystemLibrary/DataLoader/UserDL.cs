
using MediaReviewSystem.Database;
using MediaReviewSystemLibrary.Models.Entities;
using MediaReviewSystemLibrary.Utils;
namespace MediaReviewSystemLibrary.DataLoader
{
    internal class UserDL
    {
        public static void Initialize()
        {
            LoadData();
            Console.WriteLine("User detail loaded");
        }

        public static void LoadData()
        {
            var db = MediaDatabase.GetDb();
            List<string> uniqueUserNames = new List<string>
            {
                "AlexMorgan", "JordanSmith", "EmmaJohnson", "EthanBrown", "SophiaDavis",
                "LiamGarcia", "OliviaMartinez", "AidenWilson", "MiaTaylor", "NoahAnderson",
                "CharlotteMoore", "LucasThomas", "AmeliaMartin", "MasonLee", "AveryWalker",
                "ElijahHarris", "IsabellaLewis", "JamesYoung", "EllaHall", "LoganAllen",
                "AbigailKing", "JacksonWright", "ScarlettScott", "BenjaminGreen", "GraceAdams",
                "HenryBaker", "ZoeClark", "JacobCampbell", "VictoriaMitchell", "DanielPerez",
                "LilyRoberts", "WilliamTurner", "ChloePhillips", "SamuelParker", "EmilyEvans",
                "MatthewEdwards", "HannahCollins", "OwenStewart", "SamanthaFlores", "AndrewMorris",
                "LunaRivera", "NathanRodriguez", "PenelopeBell", "CarterRussell", "NoraCooper",
                "DylanFoster", "HazelSimmons", "SebastianRoss", "EllieHughes", "GabrielMorgan",
                "AriaReed", "LeviGriffin"
            };

            for (int i = 1; i <= 50; i++)
            {
                long userId = i;
                string userName = uniqueUserNames[i - 1]; // Fetch unique name for each user
                string password = $"Pass{i}word!";

                // Hash the password
                string hashedPassword = HashManager.HashPassword(password);

                // Create user details and password mappers
                UserPasswordMapper userPassword = new UserPasswordMapper(userId, hashedPassword);
                UserDetail userDetail = new UserDetail(userId, userName);

                // Add to the database
                db.AddUserPassword(userPassword);
                db.AddUserDetail(userDetail);
            }

            db.AddUserPassword(new UserPasswordMapper(101, HashManager.HashPassword("1234")));
            db.AddUserDetail(new UserDetail(101, "vasanth"));

            db.AddUserPassword(new UserPasswordMapper(100, HashManager.HashPassword("1234")));
            db.AddUserDetail(new UserDetail(100, "admin"));
        }
    }
}
