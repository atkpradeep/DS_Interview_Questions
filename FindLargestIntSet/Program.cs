

namespace FindLargestIntSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        //Find the larges integer set out of given integer array, value should be n*n (n=integer value from array)
        //if no set form then return -1, set will have maximum integer value that should be return
        //Note: array will have unique integer value in it, no duplicate value 
        //input: length = 5, array = [625, 2, 4, 5, 25,7,49]
        //output: 3
        //explanation: {2,4},{5,25},{625,25}, {625,52,5} : 4 set can be form and max length of set is 3 [{625,25,5}]
        // 2*2=4 one value {2,4}, 4*4=8 no value, 5*5=25 one value {5, 25}, 25*25=625 one value {25,625}, 5*5 =25*25=625 one value {5,25,625}
        //input: length = 4, array =[0,9,2,7]
        //output: -1
        //explanation: {} no set can be form array n*n = 0*0=0 only one value, 9*9=81 no value, 2*2=4 no value, 7*7=49 no value
        static void Main(string[] args)
        {
            Console.WriteLine("Find out larges integer set out of given array for multiples by n*n");
            //get length of array
            int arrayLength = Convert.ToInt32(Console.ReadLine());
            int[] inputArray = new int[arrayLength];

            //get input values and add into array
            for (int i = 0; i < arrayLength; i++)
            {
                inputArray[i] = Convert.ToInt32(Console.ReadLine());
            }
            //get calculated output int value
            int output = GetMaxIntegerSetLenght(inputArray, arrayLength);
            Console.WriteLine($"Max integer set length is {output}");
            Console.ReadLine();
        }

        private static int GetMaxIntegerSetLenght(int[] inputArray, int lenght)
        {
            if (inputArray.Length == 0)
                return -1;
            //sort array to get expected value in single iteration
            Array.Sort(inputArray);
            Dictionary<int, string> hashtable = new Dictionary<int, string>();
            for (int i = 0; i < lenght; i++)
            {
                int index = NewMethod(inputArray, hashtable, i);
                while (index != -1 && index < lenght)
                {
                    index = NewMethod(inputArray, hashtable, i, index);
                }
            }

            return hashtable.Select(a => a.Value.Split(',').Length).Max();
        }

        private static int NewMethod(int[] inputArray, Dictionary<int, string> hashtable, int i)
        {
            int index = Array.IndexOf(inputArray, inputArray[i] * inputArray[i]);
            if (index > -1)
                if (!hashtable.ContainsKey(inputArray[i]))
                    hashtable.Add(inputArray[i], string.Concat(inputArray[i], ",", inputArray[index]));
                else
                    hashtable.Add(inputArray[i], string.Concat(hashtable[inputArray[i]], ",", inputArray[index]));
            return index;
        }
        private static int NewMethod(int[] inputArray, Dictionary<int, string> hashtable, int i, int j)
        {
            int index = Array.IndexOf(inputArray, inputArray[j] * inputArray[j]);
            if (index > -1)
                if (!hashtable.ContainsKey(inputArray[i]))
                    hashtable.Add(inputArray[i], string.Concat(inputArray[i], ",", inputArray[index]));
                else
                    hashtable[inputArray[i]] = string.Concat(hashtable[inputArray[i]], ",", inputArray[index]);
            return index;
        }
    }
}
