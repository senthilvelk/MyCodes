using System;

namespace Pythogoras
{
    public class Program
    {
        public static bool Compute(int[] args)
        {
            int k;
            for(int i=0;i<args.Length;i++)
            {
                args[i]=args[i]*args[i];
            }

            Array.Sort(args);

            for(k=args.Length-1;k==0;k--)
            {
                for(int i=0;i<k;i++)
                {
                    if(args[i]+args[i+1]==args[k]) return true;
                }
            }
            return false;
        }

        public static void Hashing(int[] args)
        {   
            
        }
        public static void MainRun(string[] values)
        {
            int[] args={2,3,5,7,4,1,9};
            //Console.WriteLine("Result: {0}",Compute(args)); Iterative method
        }
    }
}