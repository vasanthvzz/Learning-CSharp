//Class that represents an employee in the organization
public class Employee
{
    //normal fields
    public uint EmployeeID;
    public string EmployeeName;
    public double SalaryPerHour;
    public double NoOfWorkingHours;
    public double NetSalary;

    //static field
    public static string OrganizationName;

    //constant field
    public const string TypeOfEmployee = "Contract Based";

    //readonly field
    public readonly string DepartmentName;

    //constructor: executes every time when we create an object for the Employee class.
    public Employee()
    {
        //initialize readonly field
        DepartmentName = "Finance Department";
    }
}

