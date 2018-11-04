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

class BeautifulDays {

    // Complete the beautifulDays function below.
    static int beautifulDays(int i, int j, int k) {
      //i- start range
      //j- end range
      //k- divisor
      
      int result=0;
      for(int num=i;num<=j;num++)
      {
        //find reverse
        int revNum=Reverse(num);
        Console.WriteLine(revNum);
        //Find difference
        int diff= Math.Abs(num-revNum);
        //if divisible, increment the value
        if(diff%k==0)
        {
          result++;
        }

      }

      return result;
    }

    static int Reverse(int number)
    {
      int num=number;
      int ReverseNum=0;
      while(num>0)
      {
        int rem=num%10;
        ReverseNum=ReverseNum*10+rem;
        num=num/10;
      }
      return ReverseNum;
    }

    static void MainRun(string[] args) {
        

        int result = beautifulDays(20,23,6);

        Console.WriteLine("Result: {0}",result);
    }
}
