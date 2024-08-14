public class Program
{
    static void Main()
    {
        //initialize static field
        Employee.OrganizationName = "ijsdijfs Employees";
        System.Console.WriteLine("********************************* " + Employee.OrganizationName + " *********************************");
        //loop that executes 10 times for 10 employees
        for (int i = 0; i < 10; i++)
        {
            //display employee number
            string employeeNumber;
            switch (i)
            {
                case 0: employeeNumber = "FIRST EMPLOYEE:"; break;
                case 1: employeeNumber = "SECOND EMPLOYEE:"; break;
                case 2: employeeNumber = "THIRD EMPLOYEE:"; break;
                case 3: employeeNumber = "FOURTH EMPLOYEE:"; break;
                case 4: employeeNumber = "FIFTH EMPLOYEE:"; break;
                case 5: employeeNumber = "SIXTH EMPLOYEE:"; break;
                case 6: employeeNumber = "SEVENTH EMPLOYEE:"; break;
                case 7: employeeNumber = "EIGHTH EMPLOYEE:"; break;
                case 8: employeeNumber = "NINTH EMPLOYEE:"; break;
                case 9: employeeNumber = "TENTH EMPLOYEE:"; break;
                default: employeeNumber = "OTHER EMPLOYEE:"; break;
            }
            System.Console.WriteLine(employeeNumber);

            //create an object for Employee class
            Employee emp = new Employee();

            //read EmployeeID from keyboard
            System.Console.Write("Employee ID: ");
            emp.EmployeeID = uint.Parse(System.Console.ReadLine());

            //read EmployeeName from keyboard
            System.Console.Write("Employee Name: ");
            emp.EmployeeName = System.Console.ReadLine();

            //read SalaryPerHour from keyboard
            System.Console.Write("Salary per Hour: ");
            emp.SalaryPerHour = uint.Parse(System.Console.ReadLine());

            //read NoOfWorkingHours from keyboard
            System.Console.Write("No. of Working Hours: ");
            emp.NoOfWorkingHours = uint.Parse(System.Console.ReadLine());

            //calculate NetSalary
            emp.NetSalary = emp.NoOfWorkingHours * emp.SalaryPerHour;

            //display Employee Details
            System.Console.WriteLine("\nDETAILS OF " + employeeNumber);
            System.Console.WriteLine("Employee ID: " + emp.EmployeeID);
            System.Console.WriteLine("Employee Name: " + emp.EmployeeName);
            System.Console.WriteLine("Salary per Hour: " + emp.SalaryPerHour);
            System.Console.WriteLine("No. of Working Hours: " + emp.NoOfWorkingHours);
            System.Console.WriteLine("Net Salary: " + emp.NetSalary);
            System.Console.WriteLine("Type of Employee: " + Employee.TypeOfEmployee);
            System.Console.WriteLine("Department Name: " + emp.DepartmentName);

            System.Console.Write("Do you want to continue to next employee? Yes / No: ");
            string choice = System.Console.ReadLine();

            if (!(choice == "yes" || choice == "YES" || choice == "Yes" || choice == "y" || choice == "Y"))
            {
                break;
            }

            System.Console.WriteLine("-----------------------------------"); //Separator line
        }

        System.Console.WriteLine("\nThank you.");
        System.Console.ReadKey();
    }
}

