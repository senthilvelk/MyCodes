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

class Libraries 
{
    static LinkedList<int>[] llist;
    // Complete the roadsAndLibraries function below.
    static long roadsAndLibraries(int n, int c_lib, int c_road, int[][] cities) 
    {
        int result=0;
        //Creating array of linked list to store the nodes and its neighbour
        llist=new LinkedList<int>[n+1];
        for(int item=0;item<=n;item++)
        {
            llist[item]=new LinkedList<int>();
        }

        //Construct adjacency list
        for(int item=0;item<cities.Length;item++)
        {
            int node1=cities[item][0];
            int node2=cities[item][1];
            llist[node1].AddFirst(node2);
            llist[node2].AddFirst(node1);
        }

        //Applying DFS
        if(cities.Length==0) //initiliazing the array in case no links are given- This is to handle the edge case
        {   
            cities=new int[1][];
            cities[0]=new int[1];
            cities[0][0]=0;
        }
        int StartNode=cities[0][0];

        int[] cost=new int[n+1];
        bool[] visited=new bool[n+1];

        while(StartNode!=-1)  //To iterate through the individual graphs in case if a forest exists
        {
            cost[StartNode]=c_lib; //Construct library in the first node
            DFSUtil(StartNode,cost,visited,c_lib,c_road); 
            Console.Write("END\n");
            StartNode=AllNodesVisited(visited);
        }

        //compute cost
        for(int item=1;item<=n;item++)
        {
            result+=cost[item];
        }

        //Return result
        return result;
    }

    static void DFSUtil(int node,int[] cost,bool[] visited,int c_lib,int c_road)
    {
        visited[node]=true;
        Console.Write(node+"--");
        foreach(int item in llist[node])
        {
            if(!visited[item])
            {
                if(c_lib>c_road)
                {
                    cost[item]=c_road;
                }
                else
                {
                    cost[item]=c_lib;
                }
                DFSUtil(item,cost,visited,c_lib,c_road);
            }
        }
    }

    static int AllNodesVisited(bool[] visited)
    {

        for(int item=1;item<visited.Length;item++)
        {
            if(!visited[item])
            {
                return item;
            }
        }

        return -1;
    }

    static void MainRun(string[] args) 
    {
            //With links provided
            // int n = 6;

            // int c_lib = 2;

            // int c_road = 5;

            // int[][] cities = new int[n][];

            // cities[0] = new int[]{1,3};
            // cities[1] = new int[]{3,4};
            // cities[2] = new int[]{2,4};
            // cities[3] = new int[]{1,2};
            // cities[4] = new int[]{2,3};
            // cities[5] = new int[]{5,6};

            //With no links provided
            int n = 2;

            int c_lib = 102;

            int c_road = 1;

            int[][] cities = new int[0][];

            // cities[0] = new int[2];
            // cities[1] = new int[2];

            long result = roadsAndLibraries(n, c_lib, c_road, cities);

            Console.WriteLine("Result is {0}",result);
    }

}

