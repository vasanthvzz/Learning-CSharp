public class Children
{
    public int age;
}

public class Employee
{
    public int salary;
}

public class Sample
{
    public void PrintData<T>(T obj) where T : class
    {
        if(obj.GetType() == typeof(Children))
        {
            Children temp = obj as Children;
            Console.WriteLine("Age is "+temp.age);
        }
        else if(obj.GetType() == typeof(Employee))
        {
            Employee temp = obj as Employee;
            Console.WriteLine("Salary is "+temp.salary);
        }
    }
}

class Program2
{
    static void Main()
    {
        Sample sample = new Sample();
        Employee emp = new Employee()
        {
            salary = 5000
        };
        Children child = new Children()
        {
            age = 12
        };
        sample.PrintData(emp);
        sample.PrintData(child);
    }
}