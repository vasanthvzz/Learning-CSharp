﻿using System.Collections;

class Program1
{
    public static void Main(string[] args)
    {
        int[] arr1 = { 5, 4, 3, 2, 1 };
        int[] arr2 = { 4, 5, 1, 3, 2 };

        //int[] arr1 = { 5, 4, 3, 2, 1 };
        //int[] arr2 = { 1, 2, 3, 4, 5 };

        //int[] arr1 = { 5, 4, 3, 2, 1 };
        //int[] arr2 = { 1, 5, 2, 4, 3 };

        //int[] reversedArr = Reverse(arr1);
        //List<int> list = GetSequence(arr2, reversedArr);

        List<int> list = GetReversedSequence(arr2, arr1);
        if (list.Count < 2)
        {
            Console.WriteLine("Invalid");
        }
        else
        {
            Console.WriteLine(string.Join(" , ", list));
        }
    }

    static List<int> GetReversedSequence(int[] arr1, int[] arr2)
    {
        List<int> sequenceList = new List<int>();
        int longestLength = 0;
        for (int i = 0; i < arr1.Length; i++) // iterating from left to right ->
        {
            for (int j = arr2.Length - 1; j >= 0; j--) //iterating from right to left <-
            {
                int currentLongest = 0;
                List<int> currentList = new List<int>();
                if (arr1[i] == arr2[j])
                {
                    //Altering the value of index without breaking the loop
                    int indexI = i, indexJ = j;
                    while (indexI < arr1.Length && indexJ >= 0 && arr1[indexI] == arr2[indexJ])
                    {
                        currentList.Add(arr1[indexI]);
                        indexI++;
                        indexJ--;
                        currentLongest++;
                    }
                    //Updating the value of the resulting list only if the current list length exceeds.
                    if (currentLongest > longestLength)
                    {
                        longestLength = currentLongest;
                        sequenceList = currentList;
                    }
                }
            }
        }

        return sequenceList;
    }


    static int[] Reverse(int[] arr)
    {
        int length = arr.Length;
        for (int i = 0; i < length / 2; i++)
        {
            int tempVariable = arr[i];
            arr[i] = arr[length - 1 - i];
            arr[length - 1 - i] = tempVariable;
        }
        return arr;
    }


    static List<int> GetSequence(int[] arr1, int[] arr2)
    {
        List<int> sequenceList = new List<int>();
        int longestLength = 0;
        for (int i = 0; i < arr1.Length; i++)
        {
            for (int j = 0; j < arr2.Length; j++)
            {
                int currentLongest = 0;
                List<int> currentList = new List<int>();
                if (arr1[i] == arr2[j])
                {
                    //Altering the value of index without breaking the loop
                    int indexI = i, indexJ = j;
                    while (indexI < arr1.Length && indexJ < arr2.Length && arr1[indexI] == arr2[indexJ])
                    {
                        currentList.Add(arr1[indexI]);
                        indexI++;
                        indexJ++;
                        currentLongest++;
                    }
                    //Updating the value of the resulting list only if the current list length exceeds.
                    if (currentLongest > longestLength)
                    {
                        longestLength = currentLongest;
                        sequenceList = currentList;
                    }
                }
            }
        }

        return sequenceList;
    }
}