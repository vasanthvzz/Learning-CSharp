class UpCounter
{
    public void CountUp(int count)
    {
        Console.WriteLine("\nCount-up starts");
        for (int i = 1; i <= count; i++)
        {
            Console.WriteLine($"{i}, ");
        }
        Console.WriteLine("\nCount-up end");
    }
}

class DownCounter
{
    public void CountDown(int count)
    {
        Console.WriteLine("\nCount-down starts");
        for (int j = count; j >= 1; j--)
        {
            Console.WriteLine($"{j}, ");
        }
        Console.WriteLine("\nCount-down end");
    }
}