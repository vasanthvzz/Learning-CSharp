class Program
{
    static void Main1()
    {
        Sample s = new Sample();
        Operations operation = new Operations(s.Add);
        int a = operation.Invoke(2, 5);
        Console.WriteLine(a);
    }
}