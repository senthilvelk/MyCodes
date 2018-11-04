using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GraphTest
{
    public class GraphTest
    {
        public int VertexCount;
        public LinkedList<int>[] nodes;

        public GraphTest(int vertexCount)
        {
            int count=0;
            VertexCount=vertexCount;
            nodes=new LinkedList<int>[vertexCount];
            while(count<vertexCount)
            {
                nodes[count]=new LinkedList<int>();
                count++;
            }
        }

        public void AddEdge(int source,int destination)
        {
            nodes[source].AddLast(destination);
            nodes[destination].AddLast(source);
        }

        public void DisplayGraph()
        {
            for(int level=0;level<VertexCount;level++)
            {
                Console.Write("{0}-->",level);

                foreach(int node in nodes[level].ToList())
                {
                    Console.Write("{0}-->",node);
                }
                Console.WriteLine("END");
            }
        }

        public void DFS(int startNode)
        {
            bool[] visited=new bool[VertexCount];
            DFSUtil(startNode,visited);
            Console.WriteLine("END");
        }

        public void DFSUtil(int root,bool[] visited)
        {
            Console.Write("{0}--",root);
            visited[root]=true;

            foreach(var indNode in nodes[root])
            {
                if (!visited[indNode])
                {
                    DFSUtil(indNode,visited);
                }
            }
        }

        public void BFS(int root)
        {
            Queue queue=new Queue();

            bool[] visited=new bool[VertexCount];

            queue.Enqueue(root);
            visited[root]=true;

            while(queue.Count!=0)
            {
                var value=Convert.ToInt32(queue.Dequeue());
               
                Console.Write("{0}--",value);

                foreach(var node in nodes[value])
                {
                    if(!visited[node])
                    {
                        queue.Enqueue(node);
                        visited[node]=true;
                    }
                }    
            }
            Console.WriteLine("END");
        }

        public bool BFS_ShortestPath(int source,int destination,List<int> path)
        {
            bool isFound=false;
            Queue queue=new Queue();

            bool[] visited=new bool[VertexCount];

            queue.Enqueue(source);
            visited[source]=true;

            while(queue.Count!=0)
            {
                var value=Convert.ToInt32(queue.Dequeue());
                path.Add(value);
                if (value==destination) 
                {
                    return true;
                }
               
                //Console.Write("{0}--",value);

                foreach(var node in nodes[value])
                {
                    if(!visited[node])
                    {
                        queue.Enqueue(node);
                        visited[node]=true;
                    }
                }    
            }
            //Console.WriteLine("END");
            return isFound;
        }

        public int[] BFS_PathComputation(int root)
        {
            //To enqueue and dequeue items for computation
            Queue queue=new Queue();

            //To store the distance from source root node
            int[] distance = new int[VertexCount];
            Array.Fill(distance,-1);
            
            //Enqueue root item
            queue.Enqueue(root);
            distance[root]=0;

            while(queue.Count!=0)
            {
                int value=Convert.ToInt32(queue.Dequeue());

                foreach(var node in nodes[value])
                {
                    if(distance[node]==-1)
                    {
                        queue.Enqueue(node);
                        distance[node]=distance[value]+1;
                    }
                }
            }
            return distance;
        }
    }

    public class Program
    {
        public static void MainRun(string[] cmdArgs)
        {
            GraphTest graph=new GraphTest(8);
            graph.AddEdge(0,1);
            graph.AddEdge(1,2);
            graph.AddEdge(1,3);
            graph.AddEdge(3,4);
            graph.AddEdge(2,5);
            graph.AddEdge(4,7);
            graph.AddEdge(4,5);
            graph.AddEdge(4,6);
            graph.AddEdge(5,6);
            graph.AddEdge(5,7);
            graph.AddEdge(6,7);

            Console.WriteLine("Values in the graph-Adjacency list");
            graph.DisplayGraph();

            // Console.WriteLine("DFS Implementation");
            // graph.DFS(0);

            // Console.WriteLine("BFS Implementation");
            // graph.BFS(0);

            // Console.Write("Path exists between {0} and {1}: ",0,7);
            // List<int> path=new List<int>();
            // bool pathFound=graph.BFS_ShortestPath(0,7,path);

            // Console.WriteLine(pathFound);
            // if (pathFound)
            // {
            //     Console.WriteLine("The shortest path is:"); 
            //     foreach(int value in path)
            //     {
            //         Console.Write("{0}--",value);
            //     }
            //     Console.WriteLine("END");
            // }

            Console.WriteLine("Distances of every node from the root node {0}",0);
            int[] values=graph.BFS_PathComputation(0);

            for(int value=0;value<values.Length;value++)
            {
                Console.WriteLine("Item: {0} - Distance: {1}",value,values[value]);
            }
        }
    }
}