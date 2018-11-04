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

class BFSShortReach {


    // Complete the bfs function below.
    static int[] bfs(int n, int m, int[][] edges, int s) {

        //Definitions
        int[] result=new int[n+1];
        Queue queue=new Queue();
        bool[] visited=new bool[n+1];
        int startNode,counter=0;

        //Define the Adjacency matrix based on the number of nodes given- n
        LinkedList<int>[] llist=new LinkedList<int>[n+1];
        
        for(int value=1;value<=n;value++)
        {
            llist[value]=new LinkedList<int>();
        }

        //Fill the Adjancey Matrix
        for(int node=0;node<edges.Length;node++)
        {
            int node1=edges[node][0];
            int node2=edges[node][1];

            llist[node1].AddFirst(node2);
            //llist[node2].AddFirst(node1);
        }

        //Set the start node
        startNode=s;
        Array.Fill(visited,false);
        Array.Fill(result,-1);

        //Perform BFS an store values to an integer array. The untravelled node should be -1
        queue.Enqueue(startNode);
        result[startNode]=counter;

        while(queue.Count!=0)
        {
            int nodeValue=Convert.ToInt32(queue.Dequeue());
            visited[nodeValue]=true;
            
            foreach(var node in llist[nodeValue])
            {
                if(!visited[node])
                {
                    queue.Enqueue(node);
                    result[node]=result[nodeValue]+6;
                }
            }
        }

        //Return the integer array after removing 0th index and start index
        int[] finalResult=new int[n-1];
        counter=0;
        for(int item=1;item<result.Length;item++)
        {
            if(item!=startNode)
            {
                finalResult[counter]=result[item];
                counter++;
            }
        }

        return finalResult;
    }

    static void MainRun(string[] args) {
        
            int n = 3;

            int m = 1;

            int[][] edges = new int[m][];
            //edges[0]=new int[]{3,1};
            edges[0]=new int[]{2,3};
            
            int s = 2;

            int[] result = bfs(n, m, edges, s);

            for(int value=0;value<result.Length;value++)
            {

                Console.Write("{0} ",result[value]);
            }
    }

    // static void Main(string[] args) {
    //     TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

    //     int q = Convert.ToInt32(Console.ReadLine());

    //     for (int qItr = 0; qItr < q; qItr++) {
    //         string[] nm = Console.ReadLine().Split(' ');

    //         int n = Convert.ToInt32(nm[0]);

    //         int m = Convert.ToInt32(nm[1]);

    //         int[][] edges = new int[m][];

    //         for (int i = 0; i < m; i++) {
    //             edges[i] = Array.ConvertAll(Console.ReadLine().Split(' '), edgesTemp => Convert.ToInt32(edgesTemp));
    //         }

    //         int s = Convert.ToInt32(Console.ReadLine());

    //         int[] result = bfs(n, m, edges, s);

    //         textWriter.WriteLine(string.Join(" ", result));
    //     }

    //     textWriter.Flush();
    //     textWriter.Close();
    // }
}
