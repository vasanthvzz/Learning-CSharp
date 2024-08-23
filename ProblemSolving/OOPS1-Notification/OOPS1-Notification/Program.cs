class Program
{
    static void Main(string[] args)
    {

        List<INotification> list = new List<INotification>
        {
            new Email(),
            new SMS(),
            new PushNotification()
        };

        foreach (INotification notification in list)
        {
            notification.Send();
            notification.Preview();
            notification.Log();
        }
    }
}