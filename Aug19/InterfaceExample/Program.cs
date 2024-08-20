class Program{
    static void Main(){
        IEmployee employee = new Employee();
        employee.EmpID = 2;
        Console.WriteLine(employee.EmpID);
        employee.EmpID++;
        Console.WriteLine(employee.EmpID);

    }

    static int Add(int a,int b)
    {
        return a + b;
    }

    static int Add(int a,int b,int c)
    {
        return a + b+c;
    }
}
