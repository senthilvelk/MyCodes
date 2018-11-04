using System;

namespace StockSpan
{
    public class Program
    {
        public static void Compute(int[] stock,ref int[] result)
        {
            //int[] result=new int[int.MaxValue];
            int count=0;
            for(int i=0;i<stock.Length;i++)
            {
                count=0;
                for(int j=i;j>=0;j--)
                {
                    //count++;
                    if(stock[i]>=stock[j])
                    {
                        count++;
                    }
                    else break;
                }
                result[i]=count;
            }
            //return result;
        }

        public static void MainRun(string[] cmdargs)
        {
            int[] input=new int[]{100,80,60,70,60,75,85};
            int[] result=new int[input.Length];
            Compute(input,ref result);
            foreach(int item in result)
            {
                Console.Write("{0},",item);
            }
        }
    }
}