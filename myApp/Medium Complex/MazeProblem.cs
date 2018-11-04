using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MazeProblem
{
    public class Pointe
    {
        public int x{get;set;}
        public int y{get;set;}
    }
    public class MazeProblem
    {
        public bool[,] visited;
        public int[] rowNum={-1,0,0,1};
        public int[] colNum={0,-1,1,0};

        public int ROW;

        public int COL;

        public MazeProblem(int x,int y)
        {
            this.ROW=x;
            this.COL=y;
            visited=new bool[ROW,COL];
            FillArrayToFalse();
        }

        public void FillArrayToFalse()
        {
            for(int row=0;row<ROW;row++)
            {
                for(int col=0;col<COL;col++)
                {
                    visited[row,col]=false;
                }
            }
        }
        public bool IsVisited(int x,int y)
        {
            return visited[x,y];
        }

        public bool IsValid(int x,int y)
        {
            if ((x>=0 && x<ROW) && (y>=0 && y<COL)) return true;
            else return false;
        }

        public void Compute(int[,] inputArray)
        {
            Queue<Pointe> queue=new Queue<Pointe>();
            Pointe root=new Pointe(){x=0,y=0}; //Start node
            
            queue.Enqueue(root);
            visited[root.x,root.y]=true;

            while(queue.Count !=0)
            {
                Pointe node=queue.Dequeue();
                Console.WriteLine("({0},{1})",node.x,node.y);

                if(inputArray[node.x,node.y]==9) 
                {
                    Console.WriteLine("Target found!");
                    return; //Target is reached
                }
                for(int pos=0;pos<4;pos++)
                {
                    int row=node.x+rowNum[pos];
                    int col=node.y+colNum[pos];

                    if(IsValid(row,col) && !IsVisited(row,col) && (inputArray[row,col]==1 || inputArray[row,col]==9))
                    {
                        queue.Enqueue(new Pointe(){x=row,y=col});
                        visited[row,col]=true;
                    }
                }
            }
        }
    }

    public class Program
    {
        public static void MainRun(string[] cmdArgs)
        {
            int[,] input=new int[,]
                            {   { 1, 0, 1, 1, 1}, 
                                { 1, 0, 1, 0, 1}, 
                                { 1, 1, 1, 0, 1}, 
                                { 1, 0, 0, 0, 1}, 
                                { 1, 1, 1, 0, 9}  }; 
                            
            MazeProblem maze=new MazeProblem(5,5);
            maze.Compute(input);
        }
    }
}