class Program3
{
    static void Main()
    {
        Subscriber subscriber = new Subscriber();
        Publisher publisher = new Publisher();

        publisher.myEvent += subscriber.Add;
        //Anonymous method
        publisher.myEvent += delegate (int a, int b)
        {
            Console.WriteLine("After multiplication : " + (a * b));
        };
        publisher.RaiseEvent(15, 3);
    }
}