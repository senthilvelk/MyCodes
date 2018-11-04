using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Graph_AdjacencyList
{
    public class Graph
    {
        //public int[] vertex;
        public int vertexCount;
        public LinkedList<int>[] llist;

        public Graph(int vertexCount)
        {

            this.vertexCount=vertexCount;
            
            llist=new LinkedList<int>[vertexCount];

            for(int item=0;item<vertexCount;item++)
            {
                llist[item]=new LinkedList<int>();
            }
        }

        public void AddEdge(int sourceVertex,int destVertex)
        {
            //Since this is a undirected graph, link both source and destination
            llist[sourceVertex].AddFirst(destVertex);

            llist[destVertex].AddFirst(sourceVertex);
        }

        public void Display()
        {
            for(int iteration=0;iteration<vertexCount;iteration++) //Iterate through individual linked list
            {
                Console.Write("{0}-->",iteration);
                for(int item=0;item<llist[iteration].Count;item++)
                {
                    Console.Write("{0}-->",llist[iteration].ElementAt(item));
                }
                Console.Write("END\n");
            }
        }
    }

    public class Program
    {
        public static void MainRun(string[] cmdArgs)
        {
            Console.WriteLine("Enter the number of vertices:");
            int vertexCount=Convert.ToInt32(Console.ReadLine());
            Graph myGraph=new Graph(vertexCount);
            myGraph.AddEdge(0,1);
            myGraph.AddEdge(0,3);
            myGraph.AddEdge(0,4);
            myGraph.AddEdge(1,2);
            myGraph.AddEdge(1,3);
            myGraph.AddEdge(3,4);
            myGraph.AddEdge(4,2);
            myGraph.Display();
        }
    } 
}