using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class TwoSets {

    /*
     * Complete the getTotalX function below.
     */
    static int getTotalX(int[] a, int[] b) {
      //a-factors
      //b-to be factored
      int initValue=0;
      bool flag=false;
      int result=0;
      
      Array.Sort(a);
      Array.Sort(b);

      for(int factor=0;factor<a.Length;factor++)
      {
        initValue=a[factor];
        while(initValue<=b[b.Length-1])
        {
          initValue*=a[factor];
          flag=false;
          for(int item=0;item<b.Length;item++)
          {
            if(b[item]%initValue!=0)
            {
              flag=true;
              break;
            }
          }
          if (!flag)
          {
            result++;
          }
        }
      }
      return result;
    }

    static void MainRun(string[] args) {
        
        int[] a = {2,4};

        int[] b = {16 ,32 ,96};

        int total = getTotalX(a, b);

        Console.WriteLine("Result: {0}",total);
    }
}
