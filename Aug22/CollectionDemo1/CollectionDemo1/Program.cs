class Program
{
    static void Main(string[] args)
    {
        List<int> list = new List<int>(100) { 10, 20, 30 };
        list.Capacity = 12;
        //Console.WriteLine(list.Capacity);
        list.Add(40);

        List<int> list2 = new List<int> { 50, 60, 70 };
        list.AddRange(list2);

        list.Remove(20);
        //list.RemoveAll(n => n > 30);

        list.Insert(1, 100);
        list.InsertRange(2, list2);
        //foreach (int i in list)
        //{
        //    Console.WriteLine(i);
        //}

        Console.WriteLine(list.IndexOf(100, 3));
        Console.WriteLine(list.IndexOf(100));

        int[] array = list.ToArray();

        string[] name = { "tim", "john", "ben", "jack" };
        List<string> nameList = name.ToList();
        nameList.ForEach(
            x => { Console.WriteLine(x); }
            );

        List<int> marks = new List<int>() { 30, 95, 24, 70, 61, 81 };

        //bool b = marks.Exists(m => m < 35);
        //if (b) Console.WriteLine("failed");
        //else Console.WriteLine("passed");

        //List<int> failedMarks = marks.FindAll(n => n < 35);
        //Console.WriteLine("Failed marks : ");
        //failedMarks.ForEach(x => Console.WriteLine(x));

        Dictionary<int, string> dictionary = new Dictionary<int, string>()
        {
            { 101, "Scott" },
            { 102, "Smith" },
            { 103, "Allen" }
        };
        dictionary.Add(104, "ben");
        foreach (KeyValuePair<int, string> item in dictionary)
        {
            Console.WriteLine(item.Key + "   " + item.Value);
        }
        Console.WriteLine(dictionary[101]);
        Console.WriteLine(dictionary.ContainsKey(1001));

        SortedList<int, string> sortedList = new SortedList<int, string>()
        {
            { 103, "Scott" },
            { 102, "Smith" },
            { 1010, "Allen" }
        };
        sortedList.Add(1, "ben");
        foreach (KeyValuePair<int, string> item in sortedList)
        {
            Console.WriteLine(item.Key + "   " + item.Value);
        }


    }
}