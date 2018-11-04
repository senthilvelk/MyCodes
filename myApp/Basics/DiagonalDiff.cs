using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class DiagonalDiff {

    // Complete the diagonalDifference function below.
    static int diagonalDifference(int[][] arr) {
      int lrsum=0,rlsum=0;

      //Compute length of matrix
      int size=arr[0].Length;

      //Compute left to right sum of the diagonals
      for(int item=0;item<size;item++)
      {
        lrsum+=arr[item][item];
      }

      //Compute right to left sum of the diagonals
      for(int a=0,b=size-1;a<size&&b>=0;a++,b--)
      {
        rlsum+=arr[a][b];
      }
      
      return Math.Abs(lrsum-rlsum);
    }

    static void MainRun(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[][] arr = new int[n][];

        for (int i = 0; i < n; i++) {
            arr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
        }

        int result = diagonalDifference(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
