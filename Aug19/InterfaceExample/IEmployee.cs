interface IEmployee{
    int EmpID{set;get;}
    string EmpName{get;set;}
    string Location{get;set;}

    string GetHealthInsuranceAmount();
}