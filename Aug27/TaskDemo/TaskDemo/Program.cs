class Program
{
    static void Main()
    {
        UpCounter upCounter = new UpCounter();
        DownCounter downCounter = new DownCounter();

        Task task1 = Task.Run(() =>
        {
            upCounter.CountUp(20);
        });

        Task task2 = Task.Run(() =>
        {
            downCounter.CountDown(20);
        });

        Console.ReadKey();
    }
}