using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ICEcreams_Change
{
    public class Program
    {
        public static bool Compute(ref ArrayList inputValues)
        {
            Stack myStack=new Stack();
            foreach(int inputValue in inputValues)
            {
                if(inputValue==5)
                {
                    myStack.Push(5);
                    continue;
                }
                else if(inputValue>5)
                {
                    myStack.Push(5);
                    int counter=(inputValue-5)/5;
                    for(int stackItem=0;stackItem<counter;stackItem++)
                    {
                        if(myStack.Count>0)
                        {
                            myStack.Pop();
                        }
                        else
                        {
                            return false;
                        }
                    }
                } 
            }
            return true;
        }
        public static void MainRun()
        {
            //int[] inputValues=new int[]{5, 5, 5, 10, 20, 10}; -Sample input
            Console.WriteLine("Enter values in the list of 5,10,20 only and end with EXIT statement:");
            ArrayList inputValues=new ArrayList();
            while(1==1)
            {   
                string value=Console.ReadLine();
                if(value!="EXIT")
                {
                    inputValues.Add(Convert.ToInt32(value));
                }  
                else
                { 
                    break;
                }
            }

            Console.WriteLine("Result: {0}",Compute(ref inputValues));

            //Time complexity: O(n)
            //Space complexity: O(n)
        }
    }
}