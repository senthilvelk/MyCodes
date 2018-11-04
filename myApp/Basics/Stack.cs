using System;
using System.Collections;

namespace StackExample
{
    public class Program
    {
        public static void MainRun(string[] values)
        {
            Stack list=new Stack();
            list.Push("20");
            list.Push("10");
            list.Push("30");
            list.Pop();
            foreach(var value in list)
            Console.WriteLine(value.ToString());
        }
    }
}