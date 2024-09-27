using System;
using System.Security;

delegate void MyDelegate(int a, int b);


class Program
{
    static void Main()
    {
        Talk();
    }

    static async void Talk()
    {
        Console.WriteLine("I am talking");
        Console.WriteLine();
    }

    static async void Walk()
    {
        Console.WriteLine("I am walking");
        await Task.Delay(1000);
    }
}