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

class RepeatedString {

    // Complete the repeatedString function below.
    static long repeatedString(string s, long n) {

        long result=0;
        // long subcount=0;
        // char[] item=s.ToArray();

        // for(long count=0;count<n;count++,subcount++)
        // {
        //     if(subcount==item.Length)
        //     {
        //         subcount=0;
        //     }
        //     if(item[subcount]=='a')
        //     {
        //         result++;
        //     }
        // }
        return result;
    }

    static void MainRun(string[] args) {
        
        string s = "a";

        long n = 1000000000000;

        long result = repeatedString(s, n);

        Console.WriteLine("Result: {0}",result);

    }
}
