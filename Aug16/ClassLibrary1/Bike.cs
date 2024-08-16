public class Bike{

    private string _name;
    private int _cc;
    private int _fuelCapacity;

    //Auto Implemented methods
    private int WheelCount{get;set;} = 2;

    private string[] _keywords;

    private string this[int index]{
        set{
            this._keywords[index] = value;
        }
        get{
            return _keywords[index];
        }
    }

    
    private static string _companyName;
    public string Name {
        set{
            _name = value;
        }

        get{
            return _name;
        }
    }

    public int CC{
        set;
        get;
    }

    public int fuelCapacity{
        set{_fuelCapacity = value;}
        get{return _fuelCapacity;}
    }

    public static string CompanyName{
        set{
            _companyName = value;
        }
        get{
            return _companyName; 
        }
    }
}