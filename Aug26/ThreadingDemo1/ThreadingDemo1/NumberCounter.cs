
internal class NumberCounter
{
    public void CountUp()
    {
        for (int i = 0; i <= 100; i++)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"i = {i} , ");
            //if (i == 50)
            //{
            //    Thread.Sleep(100);
            //}
        }
    }

    public void CountDown()
    {
        for (int j = 100; j >= 1; j--)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"j = {j} , ");
        }

    }
}

