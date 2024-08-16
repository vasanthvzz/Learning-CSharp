
using System.Numerics;

class Program
{
    static void Main(string[] args){
       displaySubjects(60,"English","Maths","tamil","Social","Science");
       
    }

//param modifier should be placed after optional paramenter
    private static void displaySubjects(int mark,params string[] subjects)
    {
        foreach(string subject in subjects){
            System.Console.WriteLine(subject);
        }
        System.Console.WriteLine("out of " +mark);
    }
}