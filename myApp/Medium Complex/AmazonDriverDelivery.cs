using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AmazonDriverDelivery
{
    public class Pointe
    {
        public int X{get;set;}
        public int Y{get;set;}
        public int Counter{get;set;}
        public Pointe(int m,int n,int counter)
        {
            this.X=m;
            this.Y=n;
            this.Counter=counter;
        }

    }
    public class Program
    {
        public static List<Pointe> coords;

        public static Dictionary<int,bool> visited;

        public bool IsVisited(int counter)
        {
            return visited[counter];
        }
        public static void Compute()
        {
            int sourceX=0,sourceY=0; //Starting index
            Pointe current=new Pointe(0,0,1);
            Dictionary<int,double> distance_hs=new Dictionary<int,double>();
            visited=new Dictionary<int, bool>();

            for(int iteration=0;iteration<coords.Count;iteration++)
            {
                //Compute the distance from node
                foreach(Pointe node in coords)
                {
                    
                    sourceX=node.X-current.X;
                    sourceY=node.Y-current.Y;

                    double distance=Math.Round(Math.Sqrt((sourceX*sourceX)+(sourceY*sourceY)));
                    if(!distance_hs.ContainsKey(node.Counter))
                    {
                        distance_hs.Add(node.Counter,distance);
                    }
                    else if (distance_hs[node.Counter] != -1)
                    {
                        distance_hs[node.Counter]=distance;
                    }
                }

                //Sort items to get the nearest node
                var smallest_key=(from dict in distance_hs
                                where dict.Value != -1 
                                orderby dict.Value ascending
                                select dict.Key).ToList().First();
                
                //Update the dictionary distance to -1 to mark it as visited
                int smallest=Convert.ToInt32(smallest_key);
                distance_hs[smallest]=-1;

                //Marking the node as visited
                //visited.Add(smallest,true);

                //Get the respective coordinates
                current=null;
                dynamic xxx=(from list in coords
                                    where list.Counter==Convert.ToInt32(smallest)
                                    select new
                                    {
                                        list.X,
                                        list.Y,
                                        list.Counter
                                    }).ToList();
                current=new Pointe(xxx[0].X,xxx[0].Y,xxx[0].Counter);
                
                //Display the Coordinates
                Console.WriteLine("{0},{1}",current.X,current.Y);
            }
        }

        public static void MainRun(string[] cmdArgs)
        {
            coords=new List<Pointe>();

            coords.Add(new Pointe(3,3,1));
            coords.Add(new Pointe(-1,3,2));
            coords.Add(new Pointe(3,-2,3));
            coords.Add(new Pointe(-5,-5,4));
            
            Console.WriteLine("The Amazon driver would navigate in the below order:");
            Compute();
        }
    }
}