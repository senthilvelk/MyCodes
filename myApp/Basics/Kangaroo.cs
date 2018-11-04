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

class kangarooCompute {

    // Complete the kangaroo function below.
    static string kangaroo(int x1, int v1, int x2, int v2) {

      int b=x2;
      for(int a=x1;a<(x1+v1)*10 && b<(x2+v2)*10;a=a+v1,b=b+v2)
      {
        Console.WriteLine("{0},{1}",a,b);
        if(a==b)
        {
          return "YES";
        }
      }
      return "NO";
    }

    static void MainRun(string[] args) {
        
        string result = kangaroo(0,3,4,2);

        Console.WriteLine("Result is {0}",result);
    }
}
