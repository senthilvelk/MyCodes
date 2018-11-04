using System;
using System.Collections;
using System.Collections.Generic;

namespace Graphs_BFS
{
    public class Graphs_BFS
    {
        public LinkedList<int>[] llist;

        public int vertexCount;

        public Graphs_BFS(int value)
        {
            this.vertexCount=value;
            llist=new LinkedList<int>[value];

            for(int count=0;count<value;count++)
            {
                llist[value]=new LinkedList<int>();
            }
        }

        public void AddEdge(int src,int dest)
        {
            llist[src].AddLast(dest);
            llist[dest].AddLast(src);
        }

        public void Display()
            {
}
    }

    public class Program
    {
        public static void MainRun(string[] cmdArgs)
        {
            Graphs_BFS graphs=new Graphs_BFS(4);
            graphs.AddEdge(0,1);
            graphs.AddEdge(0,2);
            graphs.AddEdge(1,3);
            graphs.AddEdge(1,4);
            graphs.AddEdge(2,3);
            graphs.AddEdge(4,4);
            graphs.AddEdge(4,2);
        }
    }
}
