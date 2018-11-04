using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Dictionary
{
    public class Program
    {
        public static void MainRun()
        {
            Dictionary<int,string> items=new Dictionary<int,string>();
            items.Add(1,"Senthil");
            items.Add(2,"Sathish");
            items.Add(3,"Gnanz");
            items.Add(4,"Sakthi");
            items.Add(5,"Senthil");

            foreach(KeyValuePair<int,string> item in items)
            {
                Console.WriteLine("Key {0} with value {1}",item.Key,item.Value);
            }
            Console.WriteLine("Sum: {0}",items.Keys.Sum());

            //var count=items.Values.Where(x=>x=="Sakthi"); - Using Lamda
            var count=from n in items.Values
                        where n=="Senthil"
                        select n;
            Console.WriteLine("Count: {0}",Convert.ToString(count.Count()));
        }
    }
}