
using System.Numerics;

class Program1
{
    public static void temp(string[] args){
        double percentange = 9.4;
        System.Console.WriteLine(CalculateTax(percentange));
        System.Console.WriteLine(CalculateTax(total:40000));
        //UpdatePercentage(9.4); throws error .. we cannot pass constants arguments
        UpdatePercentage(ref percentange);
        System.Console.WriteLine(percentange);

        int[] arr = {34,6,56,23,123,5,464,3,1,23,124,56,3,5,65,78,787,9452,72,-8};
        int low,high;
        FindLargestNumber(out high,out low,arr);
        System.Console.WriteLine(low);
        System.Console.WriteLine(high);
    }

    private static double CalculateTax(double percentange = 18)
    {
        double tax = 10000*percentange/100;
        return tax;
    }

    //default parameter should be placed after the optional paramenters
    private static double CalculateTax(double total,double percentange = 18){
        double tax = total*percentange/100;
        return tax;
    }
    
    //ref parameter
    private static void UpdatePercentage(ref double percentange){
        percentange = 12;
    }
    //out parameter
    private static void FindLargestNumber(out int min, out int max,int[] arr){
        min = int.MaxValue;
        max = int.MinValue;
        foreach(int i in arr){
            if(i < min){
                min = i;
            }
            if(i > max){
                max = i;
            }
        }
    }
}