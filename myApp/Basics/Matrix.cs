using System;
using System.Collections.Generic;
using System.Linq;

namespace Matrix
{
    class Program
    {
        public static int[,] Rotate(int[,] mat,int m,int n)
        {
            int[,] dest=new int[n+1,m+1];
             for(int r=0;r<=m;r++)
             {
                 for(int c=0;c<=n;c++)
                 {
                     //dest[c,r]=mat[r,c]; -Transpose
                     //dest[c,n-r]=mat[r,c]; -Clockwise rotation
                     dest[m-c,r]=mat[r,c]; //Anti-clockwise rotation
                 }
             }
             return dest;
        }

        public static void Display(int[,] mat,int m,int n)
        {
            for (int a=0;a<=m;a++)
            {
                for(int b=0;b<=n;b++)
                {
                    Console.Write("{0}--",mat[a,b]);
                }
                Console.WriteLine();
            }
        }
        public static void MainRun(string[] cmdargs)
        {
            //int m=2,n=3;
            int[,] source=new int[4,4]{{1,2,3,4},{5,6,7,8},{9,10,11,12},{13,14,15,16}};
            Console.WriteLine("Originial matrix");
            Display(source,source.GetUpperBound(0),source.GetUpperBound(1));

            Console.WriteLine("Rotated matrix");
            int[,] result=Rotate(source,source.GetUpperBound(0),source.GetUpperBound(1));
            Display(result,result.GetUpperBound(0),result.GetUpperBound(1));
        }
    }
}