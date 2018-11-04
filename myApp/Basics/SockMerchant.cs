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

class SocksMerchant {

    // Complete the sockMerchant function below.
    static int sockMerchant(int n, int[] ar) {

        int result=0;
        Hashtable ht = new Hashtable();
        foreach(int value in ar)
        {
            if(!ht.ContainsKey(value))
            {
                ht.Add(value,1);
            }
            else
            {
                ht[value]=Convert.ToInt32(ht[value])+1;
            }
        }

        foreach(int kvp in ht.Keys)
        {
            result=result+Convert.ToInt32(ht[kvp])/2;
        }
        return result;
    }

    static void MainRun(string[] args) {
        
        int[] ar=new int[]{1, 1, 3, 1, 2, 1, 3, 3, 3, 3 };
        int n=ar.Length;

        int result = sockMerchant(n, ar);

        Console.WriteLine("Result= {0}",result);
    }
}
