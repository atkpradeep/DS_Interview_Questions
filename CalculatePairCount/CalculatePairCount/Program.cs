

namespace CalculatePairCount
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        //Count of valid bottle and cap pairs from the given queue ('A'=bottle, 'a'=cap) 
        //inputBatch: "CaBbAAcdcCDfDea"
        //outputPairs: 6
        static void Main(string[] args)
        {
            //Hashtable to store Bottles (capital letters)
            Hashtable capSet = new Hashtable();
            Console.WriteLine($"Please provide string to find pair count:");
            string input = Console.ReadLine();
            int capitalLaterStartAscii = 'A';
            int capitalLaterEndAscii = 'Z';
            //Get chars out of string
            char[] listOfChar = input.ToCharArray();

            //sort char array to get capital leters first 
            Array.Sort(listOfChar);

            //loop for all characters
            foreach (var item in listOfChar)
            {
                if (item >= capitalLaterStartAscii && item <= capitalLaterEndAscii)
                {
                    if (capSet[item] == null)
                        capSet.Add(item, 1);
                    else
                        capSet[item] = (int)capSet[item] + 1;
                }
                else
                {
                    //get value for cap (small character)
                    var keyToSearch = char.ToUpper(item);
                    if (capSet[keyToSearch] != null)
                    {
                        capSet[keyToSearch] = (int)capSet[keyToSearch] + 1;
                    }
                }
            }
            //Loop to count combination
            int outPutpair = 0;
            foreach (DictionaryEntry item in capSet)
            {
                //take combination value
                outPutpair += (int)item.Value / 2;
            }

            Console.WriteLine($"Total pair is :{outPutpair}");
            Console.ReadLine();
        }
    }
}
