using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Hastable_uniqueitems
{
    public class Program
    {
        public static Hashtable entries; 
        public static int Compute(int[] input)
        {
            entries=new Hashtable();
            int result=-1;
            foreach(int value in input)
            {
                if(!entries.ContainsKey(value))
                {
                    entries.Add(value,1);
                }
                else
                {
                    entries[value]=Convert.ToInt32(entries[value])+1;
                }
            }
            foreach(DictionaryEntry data in entries)
            {
                if (Convert.ToInt32(data.Value)==1) 
                {
                    result=(Convert.ToInt32(data.Key));
                }
            }
            return result;
        }
        public static void MainRun(string[] cmdArgs)
        {
            int[] input=new int[]{1,5,1,6,1,5,6,2,5,1,2,3}; //2 is the unique item
            Console.WriteLine("Unique item in the list is: " + Compute(input));
        }
    }
   
}