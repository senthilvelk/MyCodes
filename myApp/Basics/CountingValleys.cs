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

class Solution {

    // Complete the countingValleys function below.

    
    static int countingValleys(int n, string s) {
        
        int level=0; //0- Sea level
        int result=0;
        bool flag=false; //set when below sea level starts and end when it returns back to sea level

        char[] steps=s.ToArray();

        foreach(char step in steps)
        {
            if(step=='U') //Uphill
            {
                level=level+1;
                if (level==0)
                {
                    flag=false;
                    result=result+1;
                }
            }
            else
            {
                level=level-1;
                if(level==-1)
                {
                    flag=true;
                }
            }
        }
        flag=false;
        return result;
    }

    static void MainRun(string[] args) {
        
        int n = 10;

        string s = "UDDDUDUU";

        int result = countingValleys(n, s);

        Console.WriteLine("Result: {0}",result);
    }
}
