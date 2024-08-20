using ClassLibrary1;

public class Program
{
    static void Main()
    {
        User<int,int> user1 = new User<int,int>();
        User<bool,string> user2 = new User<bool,string>();
        user1.RegisterationStatus = 12;
        user1.Age = 30;
        user2.RegisterationStatus = false;
        user2.Age = "10-20";
        Console.WriteLine(user1.RegisterationStatus);
        Console.WriteLine(user1.Age);
        Console.WriteLine(user2.RegisterationStatus);
        Console.WriteLine(user2.Age);
    }
}