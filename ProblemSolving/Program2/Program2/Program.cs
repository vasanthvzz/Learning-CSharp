class Program
{
    static void Main(string[] args)
    {
        string str = "xyzxyz";
        Console.WriteLine(ContiguosLength(str));
    }

    //Implemented sliding window
    //The left index moves only when right index faces a duplicate element in the hashset
    static int ContiguosLength(string str)
    {
        //xyzxyz
        int maxLength = 0;
        HashSet<char> set = new HashSet<char>(); //Hashset for fastest searching of characters  //y z
        int left = 0, right = 0;
        while (right < str.Length)
        {
            while (set.Contains(str[right]))
            {
                set.Remove(str[left++]);
            }
            set.Add(str[right++]);
            maxLength = Math.Max(maxLength, set.Count); //0 1 2
        }

        return maxLength;
    }


}