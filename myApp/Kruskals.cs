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

namespace Kruskals
{ 
    public class Edges
    {
        public int from{get;set;}
        public int to{get;set;}

        public Edges(int from,int to)
        {
            this.from=from;
            this.to=to;
        }
    }
    class Result
    {

        /*
        * Complete the 'kruskals' function below.
        *
        * The function is expected to return an INTEGER.
        * The function accepts WEIGHTED_INTEGER_GRAPH g as parameter.
        */

        /*
        * For the weighted graph, <name>:
        *
        * 1. The number of nodes is <name>Nodes.
        * 2. The number of edges is <name>Edges.
        * 3. An edge exists between <name>From[i] and <name>To[i]. The weight of the edge is <name>Weight[i].
        *
        */
        
        static LinkedList<int>[] llist;
        static Dictionary<Edges,int> collect;
        public static int kruskals(int gNodes, List<int> gFrom, List<int> gTo, List<int> gWeight)
        {

            int result=0;
            collect=new Dictionary<Edges, int>();

            //Initialize the array of linked list to hold the nodes in adjacency list
            llist=new LinkedList<int>[gNodes+1];

            for(int item=0;item<=gNodes;item++)
            {
                llist[item]=new LinkedList<int>();
            }
            
            //Convert the data to adjacency list and adges wit weight to dictionary collection
            using(var v1=gFrom.GetEnumerator())
            using(var v2=gTo.GetEnumerator())
            using(var w=gWeight.GetEnumerator())
            {
                while(v1.MoveNext() && v2.MoveNext() && w.MoveNext())
                {
                    llist[v1.Current].AddFirst(v2.Current);
                    collect.Add(new Edges(v1.Current,v2.Current),w.Current);
                }
            }

            //Perform DFS
            bool[] visited=new bool[gNodes+1];
            int[] cost=new int[gNodes+1];
            int startNode=1;

            DFSUtil(startNode,visited,cost);
            Console.Write("END\n");

            //Return result
            return result;

        }

        static void DFSUtil(int startNode,bool[] visited,int[] cost)
        {
            visited[startNode]=true;
            Console.Write("{0}--",startNode);
            foreach(var node in llist[startNode])
            {
                if(!visited[node])
                {
                    DFSUtil(node,visited,cost);
                }
            }
        }

    }

    class Kruskals
    {
        public static void Main(string[] args)
        {
            
            int gNodes = 4;
            int gEdges = 6;

            List<int> gFrom = new List<int>();
            List<int> gTo = new List<int>();
            List<int> gWeight = new List<int>();

            string[] input=new string[gEdges];
            input[0]="1 2 5";
            input[1]="1 3 3";
            input[2]="4 1 6";
            input[3]="2 4 7";
            input[4]="3 2 4";
            input[5]="3 4 5";

            for (int i = 0; i < gEdges; i++)
            {
                string[] gFromToWeight = input[i].TrimEnd().Split(' ');

                gFrom.Add(Convert.ToInt32(gFromToWeight[0]));
                gTo.Add(Convert.ToInt32(gFromToWeight[1]));
                gWeight.Add(Convert.ToInt32(gFromToWeight[2]));
            }

            int res = Result.kruskals(gNodes, gFrom, gTo, gWeight);

            Console.WriteLine("The result is {0}",res);
        }
    }
}