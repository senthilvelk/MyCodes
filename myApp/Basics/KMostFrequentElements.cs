using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace KMostFrequentElements
{
    public class Program
    {
        public static int Compute(int[] input,int size)
        {
            //Arrange records based on the occurence
            Dictionary<int,int> hashmap=new Dictionary<int,int>();
            for(int item=0;item<size;item++)
            {
                if(hashmap.ContainsKey(input[item]))
                {
                    hashmap[input[item]]=hashmap[input[item]]+1;
                }
                else
                {
                    hashmap.Add(input[item],1);
                }
            }

            //Sort the occurence in ascending order. Using Linq
            var result=from x in hashmap
                        orderby x.Value descending
                        select x.Key;
            
            //var result1=hashmap.Keys.ToList();

            foreach(int item in result)
            {
                Console.WriteLine("{0}",item);
            }
            //Return the top element
            return result.First();
        }
        public static void MainRun(string[] cmdArgs)
        {
            int[] input=new int[]{1,6,5,4,1,6,1,9};
            Console.WriteLine("Value is {0}",Compute(input,input.Length));
        }
    }
}