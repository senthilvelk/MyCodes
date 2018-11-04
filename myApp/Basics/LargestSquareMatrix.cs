using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;


namespace LargestSquareMatrix
{
    public class Program
    {
        public static int rowCount;
        public static int colCount;
        public static int FindMax(bool[,] inputArray)
        {
            int max=0;
            for(int col=0;col<colCount;col++)
            {
                for(int row=0;row<rowCount;row++)
                { 
                    max=Math.Max(max,SearchAdjacent(inputArray,row,col));
                }
            }
            return max;
        }

        public static int SearchAdjacent(bool[,] inputArray,int row,int col)
        {
            if(row>=rowCount || col>=colCount) return 0;

            if (!inputArray[row,col]) return 1;

            return 1+Math.Min(Math.Min(SearchAdjacent(inputArray,row+1,col),SearchAdjacent(inputArray,row,col+1)),
                                SearchAdjacent(inputArray,row+1,col+1));
        }

        public static void DisplayMatrix(bool[,] inputArray)
        {
            for(int col=0;col<colCount;col++)
            {
                for (int row=0;row<rowCount;row++)
                {
                    Console.Write("{0}--",inputArray[row,col]);
                }
                Console.Write("\n");
            }
        }
        public static void MainRun (string[] cmdArgs)
        {
            Console.WriteLine("Enter matrix rows and columns line by line:");
            rowCount=Convert.ToInt32(Console.ReadLine());
            colCount=Convert.ToInt32(Console.ReadLine());
             
            //Generate Matrix of boolean type
            bool[,] inputArray=new bool[rowCount,colCount];
            for(int col=0;col<colCount;col++)
            {
                for (int row=0;row<rowCount;row++)
                {
                    inputArray[row,col]=true;
                }
            }

            //Manually edit few values
            inputArray[0,0]=false;
            inputArray[2,0]=false;
            inputArray[3,2]=false;

            //Diaply the contents of the Matrix
            DisplayMatrix(inputArray);

            //Fidn the largest subsquare matrix which is all true
            Console.WriteLine("Size of the largest submatrix is {0}",FindMax(inputArray));
        }
    }
}