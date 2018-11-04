using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Fibonacci_Recursive_Dictionary
{
    public class Program
    {

        public static Dictionary<int,int> memo;
        public static int Compute(int number)
        {
            if(number<=1) return 1;
            if (!memo.ContainsKey(number))
            {
                Console.Write(number + "--");
                memo.Add(number,Compute(number-1)+Compute(number-2));
            }
            return memo.GetValueOrDefault(number);
        }

        public static void MainRun(string[] cmdArgs)
        {
            //Dictionary<int,int> memo=new Dictionary<int,int>();
            memo=new Dictionary<int,int>();
            Console.WriteLine("Enter the nth number to compute the Fibonacci value:");
            int value=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Result is {0}",Compute(value));
        }
    }
}