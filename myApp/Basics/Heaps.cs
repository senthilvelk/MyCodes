using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Heaps
{
    public class Heaps
    {
        public ArrayList items;

        public int SIZE;

        public int MAX_CAPACITY=20;

        public Heaps(int size)
        {
            this.SIZE=size;
        }
        
        public int LeftChildIndex(int node)
        {
            return (node*2+1);
        }

        public int RightChildIndex(int node)
        {
            return (node*2+2);
        }

        public int ParentNodeIndex(int node)
        {
            return ((node-1)/2);
        }
        
        public int GetLeftChildValue(int node)
        {
            return ReturnInt((items[LeftChildIndex(node)]));
        }

        public int GetRightChildValue(int node)
        {
            return ReturnInt((items[RightChildIndex(node)]));
        }

        public int GeParentValue(int node)
        {
            return ReturnInt((items[ParentNodeIndex(node)]));
        }

        public bool HasLeftChild(int node)
        {
            return (LeftChildIndex(node)<SIZE);
        }
        public bool HasRightChild(int node)
        {
            return (RightChildIndex(node)<SIZE);
        }
        public bool HasParent(int node)
        {
            return (ParentNodeIndex(node)>0);
        }

        public void Swap(int nodeA,int nodeB)
        {
            int temp;
            temp=ReturnInt(items[nodeA]);
            items[nodeA]=items[nodeB];
            items[nodeB]=temp;
        }

        public int ReturnInt(object obj)
        {
            return Convert.ToInt32(obj);
        }

        public int Peek()
        {
            //Display the topmost item
            return ReturnInt(items[0]);
        }

        public int Poll()
        {
            //Remove and Return the topmost item and then heapify
            int result=ReturnInt(items[0]);

            items[0]=ReturnInt(items[SIZE-1]);
            SIZE--;
            
            HeapifyDown();

            return result;
        }

        public void Add(int value)
        {
            //Add the new element at the end of the list and then heapify
            if (SIZE<MAX_CAPACITY)
            {
                items[SIZE]=value;
                SIZE++;
                HeapifyUp();
            }
        }
        public void HeapifyUp()
        {
            int index=SIZE-1;
            while(HasParent(ReturnInt(items[index])) && (ReturnInt(GeParentValue(index))> ReturnInt(items[index])))
            {
                Swap(ParentNodeIndex(index),index);
                index=ParentNodeIndex(index);
            }
        }
        public void HeapifyDown()
        {
            
        }
        
    }
    public class Program
    {
        public static void MainRun(string[] cmdArgs)
        {
            Heaps heapCol=new Heaps(7);
            heapCol.items=new ArrayList{2,3,1,4,5,7,8};

            Console.WriteLine("{0},{1},{2}",heapCol.GetLeftChildValue(2),heapCol.GetRightChildValue(1),heapCol.GeParentValue(6));

            Console.WriteLine("{0},{1},{2}",heapCol.HasLeftChild(3),heapCol.HasRightChild(2),heapCol.HasParent(1));

            heapCol.Swap(3,4);

            Console.WriteLine("Modified array list:");
            foreach(var value in heapCol.items)
            {
                Console.Write("{0} ",Convert.ToInt32(value));
            }
        }
    }
}