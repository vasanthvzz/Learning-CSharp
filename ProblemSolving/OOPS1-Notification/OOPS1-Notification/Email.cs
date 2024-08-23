class Email : INotification
{
    string From { get; set; }
    string To { get; set; }
    string Subject { get; set; }
    string Body { get; set; }

    public void Send()
    {
        Console.WriteLine("Email send");
    }

    public void Preview()
    {
        Console.WriteLine("Email Previewed");
    }

    public void Log()
    {
        Console.WriteLine("Email Logged");
    }

}
