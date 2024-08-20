public struct Category
{
    private int _categoryID;
    public int CategoryID{
        set{
            if(value >=1 && value < 100){
                _categoryID = value;
            }
        }
        get{
            return _categoryID;
        }
        
    }

    public string CategoryName{
        get;
        set;
    }
}