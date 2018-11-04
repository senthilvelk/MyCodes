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

class jumpingClouds {

    // Complete the jumpingOnClouds function below.
    static int jumpingOnClouds(int[] c) {

        int jumpcount=0,step=0;
        
        while(step<c.Length)
        {
            if(step+2 <c.Length)
            {
                if (c[step+2]==0)
                {
                    jumpcount++;
                    step=step+2;
                }
                else if(c[step+1]==0)
                {
                    jumpcount++;
                    step=step+1;
                }
            }
            else if (step+1 <c.Length)
            {
                if(c[step+1]==0)
                {
                    jumpcount++;
                    step=step+1;
                }
            }
            else
            {
                break;
            }
        }
        return jumpcount;
    }

    static void MainRun(string[] args) {
        
        int n = Convert.ToInt32(Console.ReadLine());

        int[] c = {0, 0 ,1 ,0 ,0 ,1, 0};
        
        int result = jumpingOnClouds(c);

        Console.WriteLine("Result: {0}",result);
    }
}
