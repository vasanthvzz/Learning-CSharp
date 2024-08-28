using System.ComponentModel.DataAnnotations;
using System.Linq;

public class TestClass
{
    public string PropertyOne_Id { get; set; }
    public string PropertyTwo { get; set; }
    public string PropertyThree { get; set; }
}

public class MainClass
{
    public static void Main()
    {
        List<TestClass> list = new()
        {
            new TestClass{PropertyOne_Id = "101", PropertyTwo = "201", PropertyThree="301"},
            new TestClass{PropertyOne_Id = "102", PropertyTwo = "201", PropertyThree="301"},
            new TestClass{PropertyOne_Id = "103", PropertyTwo = "202", PropertyThree="301"},

            new TestClass{PropertyOne_Id = "104", PropertyTwo = "202", PropertyThree="302"},

            new TestClass{PropertyOne_Id = "105", PropertyTwo = "202", PropertyThree="303"},
            new TestClass{PropertyOne_Id = "106", PropertyTwo = "203", PropertyThree="303"},

            new TestClass{PropertyOne_Id = "107", PropertyTwo = "203", PropertyThree="304"},
            new TestClass{PropertyOne_Id = "108", PropertyTwo = "203", PropertyThree="304"},
            new TestClass{PropertyOne_Id = "109", PropertyTwo = "204", PropertyThree="304"},

            new TestClass{PropertyOne_Id = "110", PropertyTwo = "205", PropertyThree="305"},

            //Linq to get the item grouped by property three if value of property two is 202
            //select the first item in the group
            //103 , 104 , 105 , 107 , 110

        };
        var resultList = list.GroupBy(e => e.PropertyThree)
            .Select(item => (item.FirstOrDefault(r => r.PropertyTwo == "202") ?? item.First()));


        //var list1 = list.GroupBy(item => item.PropertyThree).ToList();
        //List<TestClass> resultList = new List<TestClass>();
        //foreach (var item in list1)
        //{
        //    bool found = false;
        //    foreach (var element in item)
        //    {
        //        if (element.PropertyTwo == "202")
        //        {
        //            found = true;
        //            resultList.Add(element);
        //        }
        //    }
        //    if (!found)
        //    {
        //        resultList.Add(item.First());
        //    }
        //}
        foreach (var item in resultList)
        {
            Console.WriteLine(item.PropertyOne_Id);
        }


    }
}