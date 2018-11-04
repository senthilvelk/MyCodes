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

class PlusMinusClass {

    // Complete the plusMinus function below.
    static void plusMinus(int[] arr) {
      long pos=0,neg=0,zeros=0;
      long size=arr.Length;
      foreach(int value in arr)
    {
        if(value>0) {pos++;}
        else if(value<0) {neg++;}
        else if(value==0) {zeros++;}
    }
      decimal posRt= (decimal)pos / (decimal)size;
      decimal negRt=(decimal)neg / (decimal)size;
      decimal zeroRt=(decimal)zeros / (decimal)size;
      Console.WriteLine("{0}\n{1}\n{2}",posRt.ToString("0.000000"),negRt.ToString("0.000000"),zeroRt.ToString("0.000000"));
    }

    static void MainRun(string[] args) {
        
        int[] arr = {1 ,2, 3, -1, -2 ,-3, 0 ,0};

        plusMinus(arr);
    }
}
