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

namespace PDFSelection{
class Solution {

    // Complete the designerPdfViewer function below.
    static int designerPdfViewer(int[] h, string word) {

        char[] wordArr=word.ToArray();

        int length=wordArr.Length;

        int height=0;

        //Computing the maximum height
        foreach(char element in wordArr)
        {
            int item=Convert.ToInt32(element)-97;
            if(height<h[item])
            {
                height=h[item];
            }
        }

        return height*length;
    }

    static void MainRun(string[] args) {
        
        int[] h = {1,3,1,3,1,4,1,3,2,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,7};
        
        string word = "zaba";

        int result = designerPdfViewer(h, word);

        Console.WriteLine("Result is {0}",result);
    }
}
}