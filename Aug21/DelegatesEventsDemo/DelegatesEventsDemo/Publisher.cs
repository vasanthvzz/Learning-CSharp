//public delegate void myDelegate3(int a, int b);

public class Publisher
{
    //private myDelegate3 myDelegate;

    //step 1 : create event
    //public event myDelegate3 myEvent;

    public Action<int, int> myEvent; //Using action to create event


    //step 2 : raise event
    public void RaiseEvent(int a, int b)
    {
        if (this.myEvent != null)
        {
            this.myEvent(a, b);
        }
    }
}