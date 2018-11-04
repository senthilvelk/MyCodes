using System;
using System.Collections.Generic;
using System.Collections;

namespace GraphImplementation
{
    public class Graphs
    {
        public static int value;
        public LinkedList<int>[] llist;
        public Graphs(int numbers)
        {
            value=numbers;

            llist=new LinkedList<int>[numbers];

            for(int count=0;count<numbers;count++)
            {
                llist[count]=new LinkedList<int>();
            }
        }

        public static void AddEdge(Graphs graph,int source,int nodeValue)
        {
            graph.llist[source].AddLast(nodeValue);
            graph.llist[nodeValue].AddLast(source);
        }

        public static void DisplayGraph(Graphs graph)
        {
            for(int number=0;number<value;number++)
            {
                Console.Write("START-->{0}-->",number);
                foreach(var node in graph.llist[number])
                {
                    Console.Write("{0}-->",node);
                }
                Console.WriteLine("END");
            }
        }

        public static void BFS(Graphs graph,int source)
        {
            //Queue to process the vertices
            Queue queue=new Queue();

            //Track nodes visited using a boolean array
            bool[] visited=new bool[value];

            //First node always defaults to true as visited
            visited[source]=true;
            queue.Enqueue(source);

            while (queue.Count != 0)
            {
                // Dequeue a vertex from queue and print it
                source = Convert.ToInt32(queue.Dequeue());
                Console.Write(source + " ");
    
                // Get all adjacent vertices of the dequeued vertex s
                // If a adjacent has not been visited, then mark it
                // visited and enqueue it
                foreach(var node in graph.llist[source])
                {
                    if (!visited[node])
                    {
                        visited[node] = true;
                        queue.Enqueue(node);
                    }
                }
            }
        }

        public void DFS(int startNode) //Main DFS function
        {
            bool[] visited=new bool[value];
            DFSUtil(startNode,visited);
        }

        public void DFSUtil(int v,bool[] visited) //Calling DFS function
        {
            // Mark the current node as visited and print it
            visited[v] = true;
            Console.Write(v + " ");
    
            // Recur for all the vertices adjacent to this vertex
            foreach(var n in llist[v])
            {
                if (!visited[n])
                    DFSUtil(n, visited);
            }
        }

        public void FindPath(int startNode,int destNode)
        {
            //To track the visted nodes
            bool[] isVisited=new bool[value];

            //List to save the paths
            LinkedList<int> paths=new LinkedList<int>();

            //Call helper function
            bool pathExists=false;
            RecurPathFind(startNode,destNode,isVisited,paths,ref pathExists);

            if(pathExists)
            {
                Console.WriteLine("Path exists between the source and destination");
                Console.WriteLine("Path between {0} and {1} are as follows",startNode,destNode);
            
                //Write the path to console
                foreach(var node in paths)
                {
                    Console.Write("{0}-->",node);
                }
            }
            else
            {
                Console.WriteLine("No path exists!!!");
            }
        }

        //DFS applied traversal
        public void RecurPathFind(int src,int dest,bool[] isVisited,LinkedList<int> paths,ref bool pathExists)
        {
            //Setting the source node as visited
            isVisited[src]=true;
            paths.AddLast(src);
            if(dest==src)
            {
                pathExists=true;
                return;
            }
            else
            {
                foreach(var n in llist[src])
                {
                    if(!isVisited[n])
                    {
                        RecurPathFind(n,dest,isVisited,paths,ref pathExists);
                    }
                }
            }
        }
    }

    public class Program
    {
        public static void MainRun(string[] cmdArgs)
        {
            Graphs graph=new Graphs(7);

            //Add new edges
            Graphs.AddEdge(graph, 0, 1);
            Graphs.AddEdge(graph, 0, 4);
            Graphs.AddEdge(graph, 1, 2);
            Graphs.AddEdge(graph, 1, 3);
            Graphs.AddEdge(graph, 1, 4);
            Graphs.AddEdge(graph, 2, 3);
            Graphs.AddEdge(graph, 3, 4);
            //Graphs.AddEdge(graph, 5, 0);
            Graphs.AddEdge(graph, 5, 6);

            //Display graph content as a list
            Console.WriteLine("The graph content- Adjacency list:");
            Graphs.DisplayGraph(graph);
            Console.Write("\n");

            // //Breadth first search
            // Console.WriteLine("\nBreadth first traversal");
            // Graphs.BFS(graph,0); //Start the traversal from node 0

            // //Depth first search
            // Console.WriteLine("\nDepth first traversal");
            // graph.DFS(0);

            //Find path between nodes- From source to destination
            int src=0,dest=4;
            graph.FindPath(src,dest);
        }
    }
}