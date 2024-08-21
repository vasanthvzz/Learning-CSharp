class Program1
{
    static void Main2()
    {
        Sample2 sample = new Sample2();
        MyDelegate2 myDelegate;
        myDelegate = sample.Add;
        myDelegate += sample.Subtract;
        myDelegate += sample.Multiply;
        myDelegate += sample.Division;
        myDelegate.Invoke(4, 5);
    }
}