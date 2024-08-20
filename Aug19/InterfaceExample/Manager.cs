public class Manager : IEmployee,IPerson{

    public int EmpID {
         get;set;
    }
    public string EmpName { 
         get;set;
    }
    public string Location {
         get; set;
    }
    public DateTime DateOfBirth {
        get;set;
    }

    public string GetHealthInsuranceAmount(){
        return "5000";
    }
}