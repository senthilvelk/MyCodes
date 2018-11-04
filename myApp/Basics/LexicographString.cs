using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LexicographString
{
    public class Program
    {
        public static void Sort(ref char[] input,int k,int count) //O(k^2)
        {   
            char temp;
            for(int i=count;i<k+count;i++)
            {
                for(int j=i+1;j<k+count;j++)
                {
                    if(input[j]<input[i])
                    {
                        temp=input[i];
                        input[i]=input[j];
                        input[j]=temp;
                        return;
                    }
                }
            }
        }

        public static void MainRun(string[] cmdargs)
        {
            Console.WriteLine("Input string:");
            char[] inputString=Console.ReadLine().ToCharArray(); //O(n)
            
            Console.WriteLine("Enter K value:");
            int value=Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter no. times to continue the operation:");
            int count=Convert.ToInt32(Console.ReadLine());

            for (int item=0;item<count;item++)
                Sort(ref inputString,value,item);

            string resultString=new string(inputString);
            Console.WriteLine("Output string is {0}",resultString);

            //Total Time complexity: O(n+k^2)
            //Space complexity: O(n)
        }
    }
}