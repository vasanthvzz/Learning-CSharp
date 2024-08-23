using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        string s1 = "abc";
        string s2 = "lecabee";
        Console.WriteLine(PermutationExist(s1, s2));
    }

    static bool PermutationExist(string s1, string s2)
    {
        if (s1.Length > s2.Length)
        {
            return false;
        }
        List<char> list1 = s1.ToList();
        list1.Sort();

        Console.WriteLine(s1);
        for (int i = 0; i < s2.Length - s1.Length; i++)
        {
            List<char> list2 = s2.ToList();
            list2.Sort();
            if (list1 == list2)
            {
                return true;
            }
        }
        return false;
    }

    static bool PermutationExist1(string s1, string s2)
    {
        int[] counter1 = new int[26]; //Holds the occurance of character in string 1
        int[] counter2 = new int[26]; //Holds the occurance of character in string 2

        if (s1.Length > s2.Length)
        {
            return false;
        }

        for (int i = 0; i < s1.Length; i++)
        {
            counter1[s1[i] - 'a'] += 1;
        }
        for (int i = 0; i < s1.Length; i++)
        {
            counter1[s1[i] - 'a'] += 1;
        }
        return false;
    }
}