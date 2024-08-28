class Program
{
    static void Main()
    {
        //Get main thread
        Thread mainThread = Thread.CurrentThread;
        mainThread.Name = "Main thread";
        Console.WriteLine(mainThread.Name);//Main thread

        //Create first thread
        NumberCounter numberCounter = new NumberCounter();
        ThreadStart threadStart1 = new ThreadStart(numberCounter.CountUp);
        Thread thread1 = new Thread(threadStart1)
        {
            Name = "Count-up thread",
            Priority = ThreadPriority.Highest
        };
        thread1.Start();

        //create second thread
        ThreadStart threadStart2 = new ThreadStart(numberCounter.CountDown);
        Thread thread2 = new Thread(threadStart2);
        thread1.Name = "Count-Down-Thread";
        thread2.Priority = ThreadPriority.BelowNormal;
        thread2.Start();

        thread1.Join();
        thread2.Join();

        Console.WriteLine(mainThread.Name + " is completed");
    }

}