public class Car
{
    public string carBrand;
    public string carModel;
    public int carYear;
    public static string companyName;
    //instance constructor
    public Car(string carBrand, string carModel, int carYear)
    {
        this.carBrand = carBrand;
        this.carModel = carModel;
        this.carYear = carYear;
    }

    public Car(string carModel){
        this.carBrand = carModel;
    }

    public Car(string carBrand,string carModel = ""){
        this.carBrand =carBrand;
    }

    public Car(string carModel,int carYear){
        this.carBrand = carModel;  
        this.carYear = carYear;    
    }

    public Car(){
        carYear = 2024;
    }

    static Car(){
        companyName = "kmdfas car resale";
        
    }

}