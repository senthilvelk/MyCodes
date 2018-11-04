using System;
using System.Collections;

namespace QueueExample
{
    public class Program
    {
        public static void MainRun(string[] cmdargs)
        {
            Queue qu=new Queue();
            qu.Enqueue(20);
            qu.Enqueue(30);
            qu.Enqueue(37);
            qu.Dequeue();
            foreach(var list in qu)
            {
                Console.WriteLine(list.ToString());
            }
        }
    }
}