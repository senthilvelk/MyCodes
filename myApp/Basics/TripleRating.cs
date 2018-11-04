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

class TripleRating {

    // Complete the compareTriplets function below.
    static List<int> compareTriplets(List<int> a, List<int> b) {
        int AliceScore=0;
        int BobScore=0;
        List<int> scores=new List<int>();

        //Iterate the list simultaneously
        using (var e1 = a.GetEnumerator())
        using (var e2 = b.GetEnumerator())
        {
            while (e1.MoveNext() && e2.MoveNext())
            {
                if(e1.Current>e2.Current)
                {
                  AliceScore++;
                }
                else if(e1.Current<e2.Current)
                {
                  BobScore++;
                }
                else if(e1.Current==e2.Current)
                {
                  continue;
                }
            }
        }

        //Add results and return.
        scores.Add(AliceScore);
        scores.Add(BobScore);
        return scores;
    }

    static void MainRun(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

        List<int> b = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(bTemp => Convert.ToInt32(bTemp)).ToList();

        List<int> result = compareTriplets(a, b);

        textWriter.WriteLine(String.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
