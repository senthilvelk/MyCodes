using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BinaryString
{
    public class Node
    {
        public char value;
        public Node right;

        public Node (char value)
        {
            this.value=value;
            this.right=null;
        }
    }

    public class LinkedList
    {
        public Node head;
        public void Push(char value)
        {
            if(head==null)
            {
                head=new Node(value);
                return;
            }
            Node newnode=new Node(value);
            newnode.right=head;
            head=newnode;
        }

        public void Display()
        {
            Node current=head;
            while(current!=null)
            {
                Console.Write("{0}-->",current.value);
                current=current.right;
            }
            Console.Write("END\n");
        }

        public char FindIndex(int index)
        {
            Node current=head;
            int count=1;
            while(count<=index)
            {
                if(current==null) return ('-');
                current=current.right;
                count++;
            }
            return (current.value);
        }

        public void ApplyPadding()
        {
            Node current=head;
            Node one=new Node('1');
            Node zero=new Node('0');

            while(current!=null)
            {
                if(current.value=='0')
                {
                    Node newnode=one;
                    newnode.right=current.right;
                    current.right=newnode;
                    current=current.right.right;
                }
                else if(current.value=='1')
                {
                    Node newnode=zero;
                    newnode.right=current.right;
                    current.right=newnode;
                    current=current.right.right;
                }
            }
        }
    }
    public class Program
    {
        public static void MainRun(string[] cmdArgs)
        {
            Console.WriteLine("Enter a number");
            int number=Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the number of iterations:");
            int count=Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the index to return the value:");
            int index=Convert.ToInt32(Console.ReadLine());

            LinkedList llist=new LinkedList();
            try
            {
                string bits=Convert.ToString(number,2); //Convert to base 2, ie., 0's and 1's
                char[] bitArray=bits.ToArray();
                Console.WriteLine("Initial bit values:");
                for(int i=0;i<bitArray.Length;i++)
                {
                    Console.Write("{0}-->",bitArray[i]);
                    llist.Push(bitArray[i]);
                }
                Console.Write("END\n");

                for(int i=0;i<count;i++)
                {
                    llist.ApplyPadding();
                    Console.WriteLine("After iteration {i}:");
                    llist.Display();
                }
                Console.WriteLine("Final bit value:");
                llist.Display();

                Console.WriteLine("Value at the index: {0} is {1}",index,llist.FindIndex(index));
            }
            catch(Exception exec)
            {
                Console.WriteLine(exec.Message);
            }
            finally
            {
                llist=null;
            }
        }
    }
}