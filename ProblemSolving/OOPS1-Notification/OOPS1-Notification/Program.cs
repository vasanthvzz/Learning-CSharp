class Program
{
    static void Main(string[] args)
    {

        INotification email = new Email();
        INotification sms = new SMS();
        INotification pushNotification = new PushNotification();

        email.Send();
        email.Preview();
        email.Log();

        sms.Send();
        sms.Preview();
        sms.Log();

        pushNotification.Send();
        pushNotification.Preview();
        pushNotification.Log();
    }
}