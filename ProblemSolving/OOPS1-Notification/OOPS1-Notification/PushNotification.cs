class PushNotification : INotification
{
    string DeviceID { get; set; }
    string Message { get; set; }

    public void Send()
    {
        Console.WriteLine("Push notification send");
    }

    public void Preview()
    {
        Console.WriteLine("Push notification Previewed");
    }

    public void Log()
    {
        Console.WriteLine("Push notification Logged");
    }

}
