using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReviewSystem.DataLoader
{
    internal class UserDL
    {
        public static void LoadData()
        {
            var db = MovieDatabase.GetDB();
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
                int userId = i;
                string userName = uniqueUserNames[i - 1]; // Fetch unique name for each user
                string password = $"Pass{i}word!";
                db.GetUserList().Add(new User(userId, userName, password));
            }
            db.GetUserList().Add(new User(100, "vasanth", "1234"));
        }

        public static void ViewData()
        {
            foreach (User user in MovieDatabase.GetDB().GetUserList())
            {
                Console.WriteLine($"{user.UserId}  {user.UserName}   {user.Password}");
            }
        }
    }
}



