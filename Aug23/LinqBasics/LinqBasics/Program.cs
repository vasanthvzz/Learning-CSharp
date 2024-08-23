using System.Linq;

class Employee
{
    public int EmpID { get; set; }
    public string EmpName { get; set; }
    public string Job { get; set; }
    public string City { get; set; }
    public int Salary { get; set; }
}

class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>()
        {
            new Employee(){EmpID = 101,EmpName = "Henry",Job = "Designer",City = "Boston" ,Salary = 7232},
            new Employee(){EmpID = 102,EmpName = "Jack",Job = "Developer",City = "New york" ,Salary = 4500 },
            new Employee(){EmpID = 103,EmpName = "Gabriel",Job = "Analyst",City = "Tokyo" ,Salary = 1293 },
            new Employee(){EmpID = 104,EmpName = "Willian",Job = "Manager",City = "Tokyo" ,Salary = 2873 },
            new Employee(){EmpID = 105,EmpName = "Alexa",Job = "Manager",City = "New york" ,Salary = 6232},
            new Employee(){EmpID = 106,EmpName = "Jessica",Job = "Manager",Salary = 4545}
        };

        IEnumerable<Employee> sortedEmployees = employees.OrderBy(emp => emp.Job)
            .ThenBy(emp => emp.EmpName);

        Employee e = employees.Where(emp => emp.Job == "Manager").ElementAtOrDefault(3);
        //Console.WriteLine(e.EmpName);




        //foreach (Employee emp in sortedEmployees)
        //{
        //    Console.WriteLine(emp.Job + "   " + emp.EmpName
        //        );
        //}

        //Employee firstEmployee = employees.First(emp => emp.Job == "testing");
        //Console.WriteLine(firstEmployee.EmpName + "  " + firstEmployee.Job);

        //Employee firstEmp = employees.FirstOrDefault(emp => emp.Job == "testing");
    }
}