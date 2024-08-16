using System.ComponentModel.DataAnnotations;

public class Program
{
    static void Main2()
    {
        Car car1 = new Car("Toyota","Camery",2012);
        Car car2 = new Car("Ford","Mustang",2024);
        Car car3 = new Car("Hindustan motor","Ambassador",2000);


//Object initializer 
        Car temp = new Car(){
            carBrand = "maruthi",
            carModel = "swift"
        };
        System.Console.WriteLine(temp.carYear);
    }
}