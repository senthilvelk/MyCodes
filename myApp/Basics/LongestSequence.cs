using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace LongestSequence
{
    public class Program
    {
        public static int FindLongestSequence(int[] input,int size)
        {
            int longest=1;
            int count=1;
            int current=0;
            //Convert all values to Hashtable for faster searching
            Dictionary<int,bool> convertedValues=new Dictionary<int,bool>();
            for(int i=0;i<size;i++)
            {
                convertedValues.Add(input[i],true);
            }
            // foreach(int values in convertedValues.Keys)
            // {
            // Console.WriteLine("{0}",values);
            // }
            //var values= convertedValues.Keys;

            //Iterate through elements from the start
            foreach(int value in input)
            {
                if(convertedValues[value]) //&& convertedValues[value]==true
                {
                    current=value;
                    if(convertedValues.ContainsKey(current-1))
                    {
                        current=current-1;
                        convertedValues[current]=false;
                        while(convertedValues.ContainsKey(current+1))
                        {
                            count++;
                            current++;
                            convertedValues[current]=false;
                        }
                    }
                longest=Math.Max(longest,count);
                count=1;
                }
            }
            //Return result
            return longest;
        }
        public static void MainRun(string[] cmdArgs)
        {
            int[] input=new int[]{2,1,5,7,3,4};
            Console.WriteLine("Longest sequence: count {0}",FindLongestSequence(input,6));
        }
    }
}
