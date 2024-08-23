class SMS : INotification
{
    string To { get; set; }
    string Message { get; set; }

    public void Send()
    {
        Console.WriteLine("SMS send");
    }

    public void Preview()
    {
        Console.WriteLine("SMS Previewed");
    }

    public void Log()
    {
        Console.WriteLine("SMS Logged");
    }

}
